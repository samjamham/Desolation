using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineCamera StartCam;
    CinemachineCamera currentCam;

    [SerializeField]
    CinemachineCamera PlayerCam;
    [SerializeField]
    CinemachineCamera TopDownCam;

    void Start()
    {
        currentCam = PlayerCam;
        SwapCamTo(currentCam);
    }

        public void SwapCamTo(CinemachineCamera TargetCam)
    {
        currentCam.Priority = 0;
        TargetCam.Priority = 10;
    }

}
