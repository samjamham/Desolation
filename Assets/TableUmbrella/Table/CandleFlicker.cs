using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class CandleFlicker : MonoBehaviour
{
    private float baseIntenstiy;
    [SerializeField] private bool Ficker;
    [SerializeField, Range(0, 1)] private float MinTime;
    [SerializeField, Range(0, 1)] private float MaxTime;
    private float timeout =0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseIntenstiy = transform.GetComponent<Light>().intensity;

        if (MinTime > MaxTime)
        {
            MinTime = MaxTime;
        }
        timeout = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ficker) 
        {
            return;
        }
        if (timeout < 0)
        {
            float randy = (((float)Random.Range(0, 100) - 50f) / 100f) + baseIntenstiy;
            transform.GetComponent<Light>().intensity = randy;
            timeout = Random.Range(MinTime, MaxTime);
        }


        timeout -= Time.deltaTime;
    }
}
