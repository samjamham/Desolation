using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Splines.Interpolators;

public class NavigatorPathTracer : MonoBehaviour
{
    [SerializeField] private SplineContainer m_Spline;
    [Range(0,20)] public float m_Duration;
    private float m_Time;
    public bool m_Puased = true;

    void FixedUpdate()
    {
        if (m_Puased)
            return;
        if (m_Spline.Spline.Count <= 0)
            return;
        if (m_Duration <= 0)
            return;

        float timer = m_Time / m_Duration;
        m_Spline.Evaluate(timer, out float3 p, out float3 t, out float3 u);
        transform.position = p;

        if(timer > 1)
        {
            m_Time = 0;
        }
        m_Time += Time.deltaTime;
    }

    public void TracerReset(bool autoPlay)
    {
        TracerReset(autoPlay, 1);
    }
    public void TracerReset(bool autoPlay, float duration)
    {
        m_Time = 0;
        m_Duration = duration;
        float timer = m_Time / m_Duration;
        m_Spline.Evaluate(timer, out float3 p, out float3 t, out float3 u);
        transform.position = p;
        m_Puased = !autoPlay;
    }
}
