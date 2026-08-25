using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MapInteraction : FirstPersonInteraction
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject ScryMapDrag;

    [SerializeField] CameraManager CameraManager;
    [SerializeField] CinemachineCamera TopDownCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {        
        CameraManager.SwapCamTo(TopDownCam);
        TopDownCam.GetComponent<TDCFacePlayer>().RotateToPlayer(); //Maybe dont use
        ScryMapDrag.GetComponent<ScryMapDrag>().SetViewAngle(TopDownCam.transform.rotation.eulerAngles.y); //Maybe dont use
        StartCoroutine(SwitchContorlMethods());
    }

    IEnumerator SwitchContorlMethods()
    {
        Player.GetComponent<PlayerInput>().enabled = false;
        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        ScryMapDrag.GetComponent<PlayerInput>().enabled = true;

    }
}
