using Unity.Cinemachine;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class ScryMapDrag : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject ScryMap;
    private GameObject ZoomPivot;

    private float ZoomLevel;
    [SerializeField, Range(0.1f, 2f)]
    private float MaxScale;
    [SerializeField, Range(0.1f, 2f)]
    private float MinScale;



    private bool MouseHeld = false;
    private Vector2 MouseLastFrame = Vector2.zero;
    private Vector2 MouseMovement = Vector2.zero;
    private Vector3 MousePosition = Vector2.zero;



    private float Rotation = 0;

    [SerializeField]
    CameraManager CameraManager;
    [SerializeField]
    CinemachineCamera PlayerCamera;

    private void Start()
    {
        ScryMap = GameObject.FindGameObjectWithTag("ScryMap");
        ZoomPivot = ScryMap.transform.GetChild(0).gameObject;

        ZoomLevel = ScryMap.transform.localScale.x;

    }

    private void Update()
    {
        if (MouseHeld)
        {
            ZoomPivot.transform.position = new Vector3(ZoomPivot.transform.position.x + MouseMovement.x, ZoomPivot.transform.position.y, ZoomPivot.transform.position.z + MouseMovement.y);
        }
        MouseMovement = Vector2.zero;
    }

    public void SetViweAngle(float value)
    {
        Rotation = value;
    }    

    void OnReturnToPlayer(InputValue value)
    {  
        this.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MouseHeld = false;

        Player.GetComponent<PlayerInput>().enabled = true;
        CameraManager.SwapCamTo(PlayerCamera);
    }

    void OnMouseHold(InputValue value)
    {
        if(value.Get<float>() == 1)
        {
            //Debug.Log("Down");
            MouseHeld = true;
        }
        else
        {
            //Debug.Log("Up");
            MouseHeld = false;
        }
    }

    private void OnDrag(InputValue value)
    {
        MouseMovement = value.Get<Vector2>() - MouseLastFrame;
        MouseMovement.x *= (2.5f/Screen.width);
        MouseMovement.y *= (2.5f/Screen.height);

        Vector3 test = Quaternion.AngleAxis(Rotation, Vector3.up) * new Vector3(MouseMovement.x, 0f, MouseMovement.y);
        MouseMovement = new Vector2(test.x, test.z);
        Vector3 v3 = value.Get<Vector2>();
        v3.z = 9.4f; //distance between table and camera
        MousePosition = Camera.main.ScreenToWorldPoint(v3);
        MousePosition.y = 0f;

        MouseLastFrame = value.Get<Vector2>();
    }

    private void OnScrollWheel(InputValue value)
    {
        float ScaleAmount = 1f;
        ScaleAmount += value.Get<Vector2>().y * 0.1f;

        ////
        ZoomLevel *= ScaleAmount;
        ZoomLevel = Mathf.Clamp(ZoomLevel, MinScale, MaxScale);
        float OldRange = (MaxScale - MinScale); //NewScaleY changes by %90
        float NewRange = ((MaxScale) * 0.9f - (MinScale * 1.1f));
        float NewScaleY = (((ZoomLevel - MinScale) * NewRange) / OldRange) + (MinScale * 1.1f);
        ////
        Shader.SetGlobalFloat("_Zoomies", NewScaleY);

        Vector3 NewScale = new Vector3(ZoomLevel, NewScaleY, ZoomLevel);

        scaleAroundMouse(NewScale);
    }

    private void scaleAroundMouse(Vector3 NewScale)
    {
        Vector3 Distance = -(ZoomPivot.transform.position - MousePosition);
        ZoomPivot.transform.parent = this.transform;
        ScryMap.transform.position += MousePosition;
        ZoomPivot.transform.parent = ScryMap.transform;
        ScryMap.transform.localScale = NewScale;
        ZoomPivot.transform.parent = this.transform;
        ScryMap.transform.position -= MousePosition;
        ZoomPivot.transform.parent = ScryMap.transform;
        ZoomPivot.transform.localScale = new Vector3(1f,1f,1f);
    }
}
