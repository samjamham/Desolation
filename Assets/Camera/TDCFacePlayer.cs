using Unity.Mathematics;
using UnityEngine;

public class TDCFacePlayer : MonoBehaviour
{

    [SerializeField] GameObject Player;

    private static float RadToDEG = 57.2958f;
    void FixedUpdate()
    {

    }

    /// <summary>
    /// Rotate the topdown camera to have the bottom face towards the side of the board the player entered from
    /// </summary>
    public void RotateToPlayer()
    {
        Vector3 DirToPlayer = transform.position - Player.transform.position;
        DirToPlayer = DirToPlayer.normalized;
        float Angle = Mathf.Atan2(DirToPlayer.x, DirToPlayer.z) * RadToDEG;
        Angle = (Mathf.Round(Angle / 90f) * 90f) / RadToDEG;
        transform.rotation = quaternion.EulerZXY(90f / RadToDEG, Angle, 0f);
    }
}
