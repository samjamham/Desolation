using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapInteraction : MonoBehaviour, IFirstPersonInteractable
{
    [SerializeField]
    private bool canInteract;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject ScryMapDrag;

    [SerializeField]
    CameraManager CameraManager;
    [SerializeField]
    CinemachineCamera TopDownCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Player.GetComponent<PlayerInput>().enabled = false;
        CameraManager.SwapCamTo(TopDownCam);

        TopDownCam.GetComponent<TDCFacePlayer>().RotateToPlayer(); //Maybe dont use
        ScryMapDrag.GetComponent<ScryMapDrag>().SetViweAngle(TopDownCam.transform.rotation.eulerAngles.y); //Maybe dont use


        ScryMapDrag.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public bool CanInteract()
    {
        return canInteract;
    }
}
