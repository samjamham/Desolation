using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControls : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float sensX = 0.2f;
    [Range(0.0f, 1.0f)]
    public float sensY = 0.2f;

    private Vector2 LookInput;
    private Vector2 Rotation;
   
    [SerializeField]
    private GameObject CamOre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, Rotation.y, this.transform.rotation.z);
        CamOre.transform.rotation = Quaternion.Euler(-Rotation.x, Rotation.y, this.transform.rotation.z);
    }

    void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();
        LookInput.x *= sensX;
        LookInput.y *= sensY;
        Rotation = Rotation + new Vector2(LookInput.y, LookInput.x) ;
        Rotation.x = Mathf.Clamp(Rotation.x, -90, 90);
    }
}
