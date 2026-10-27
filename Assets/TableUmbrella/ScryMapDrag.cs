using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScryMapDrag : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject ScryMap;
    [SerializeField] private StorageManager m_StorageManager;
    private MapInteractionControls MapInteract; //Component of ScryMap
    private GameObject ZoomPivot; //Child of ScryMap

    private float ZoomLevel;
    [SerializeField, Range(0.1f, 2f)] private float MaxScale;
    [SerializeField, Range(0.1f, 2f)] private float MinScale;

    private bool MouseHeld = false;
    private Vector2 MouseLastFrame = Vector2.zero;
    private Vector2 MouseMovement = Vector2.zero;
    private Vector3 MousePosition = Vector2.zero;

    private float Rotation = 0;

    [SerializeField] CameraManager CameraManager;
    [SerializeField] CinemachineCamera PlayerCamera;

    public bool m_InputBlocker { get; private set; }


    private void Start()
    {
        ScryMap = GameObject.FindGameObjectWithTag("ScryMap");
        MapInteract = ScryMap.GetComponent<MapInteractionControls>();
        ZoomPivot = ScryMap.transform.GetChild(0).gameObject;

        ZoomLevel = ScryMap.transform.localScale.x;
        
        m_InputBlocker = false; 
    }

    private void Update()
    {
        if (MouseHeld)
        {
            ZoomPivot.transform.position = new Vector3(ZoomPivot.transform.position.x + MouseMovement.x, ZoomPivot.transform.position.y, ZoomPivot.transform.position.z + MouseMovement.y);
        }
        MouseMovement = Vector2.zero;
    }

    public void SetBlocker(bool value)
    {
        m_InputBlocker = value;
    }

    public void SetViewAngle(float value)
    {
        Rotation = value;
    }    
    public void OnEnterTopDown()
    {
        ScryMap.GetComponent<MapController>().EnterTopDown();
    }
    public void ReturnHome()
    {
        ScryMap.GetComponent<MapController>().ReturnHome(this);
    }
    public void Additems(List<Item> items)
    {
        m_StorageManager.AddItems(items);
    }
    void OnReturnToPlayer(InputValue value)
    {  
        this.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MouseHeld = false;
        PlayerManager.ChangePlayMode(PlayerManager.Playmode.FirstPerson);
        Player.GetComponent<PlayerInput>().enabled = true;
        CameraManager.SwapCamTo(PlayerCamera);
        ScryMap.GetComponent<MapController>().ReturnToPlayer();
    }

    void OnMouseHold(InputValue value)
    {
        if (m_InputBlocker)
        {
            return;
        }
        MouseHeld = true;
    }
    void OnMouseClick(InputValue value)
    {        
        if (value.Get<float>() == 1) //1 is mouse down. 0 is mouse up.
        {
            if (m_InputBlocker)
            {
                return;
            }
            MouseHeld = MapInteract.OnInteract(MouseLastFrame);
        }
        else
        {
            MouseHeld = false;
        }
    }
    void OnMouseClickAlt(InputValue value)
    {
        if (m_InputBlocker)
        {
            return;
        }
        if (value.Get<float>() == 1)
        {
            MapInteract.OnInteractAlt(MouseLastFrame);
        }
    }

    private void OnPointerPos(InputValue value)
    {
        MouseMovement = value.Get<Vector2>() - MouseLastFrame;
        MouseMovement.x *= (2.75f / Screen.width);
        MouseMovement.y *= (2.75f / Screen.height);

        Vector3 CamaeraRotation = Quaternion.AngleAxis(Rotation, Vector3.up) * new Vector3(MouseMovement.x, 0f, MouseMovement.y);
        MouseMovement = new Vector2(CamaeraRotation.x, CamaeraRotation.z);
        Vector3 v3 = value.Get<Vector2>();
        v3.z = Vector3.Distance(Camera.main.transform.position, new Vector3(0f, 0.7f, 0f)); //distance between table and camera
        MousePosition = Camera.main.ScreenToWorldPoint(v3);
        MousePosition.y = 0f;

        MouseLastFrame = value.Get<Vector2>();
    }

    private void OnScrollWheel(InputValue value)
    {
        if (m_InputBlocker)
        {
            return;
        }
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
