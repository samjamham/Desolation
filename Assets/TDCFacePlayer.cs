using Unity.Mathematics;
using UnityEngine;

public class TDCFacePlayer : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    void FixedUpdate()
    {

    }
    public void RotateToPlayer()
    {
        Vector3 DirToPlayer = transform.position - Player.transform.position;
        DirToPlayer = DirToPlayer.normalized;
        float Angle = Mathf.Atan2(DirToPlayer.x, DirToPlayer.z) * 57.2958f;
        Angle = Mathf.Round(Angle / 90f) * 90f;
        Angle /= 57.2958f;
        transform.rotation = quaternion.EulerZXY(90f / 57.2958f, Angle, 0f);
    }
}
