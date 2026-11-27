using UnityEngine;

public class WaterTower : MonoBehaviour
{
    [field: SerializeField] public float m_Capacity { get; private set; } //In Litres (L)
    [field: SerializeField] public float m_CurrentVolume {  get; private set; } //In Litres (L)

    [SerializeField] private WaterTower m_Partner;
    [SerializeField] private GameObject m_Display;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float RemoveVolume(float value)
    {
        value = Mathf.Abs(value);
        float amountShort = Mathf.Max(value - m_CurrentVolume, 0);
        m_CurrentVolume -= value;
        m_CurrentVolume = Mathf.Max(0, m_CurrentVolume);
        SetDisplay();
        return amountShort;
    }
    float AddVolume(float value)
    {
        value = Mathf.Abs(value);
        float amountExcess = Mathf.Max(value - (m_Capacity - m_CurrentVolume), 0);
        m_CurrentVolume += value;
        m_CurrentVolume = Mathf.Min(m_Capacity, m_CurrentVolume);
        SetDisplay();
        return amountExcess;
    }

    public void Transfer(float volume)
    {
        float transferAmount = Mathf.Min(Mathf.Min(volume, m_CurrentVolume), m_Partner.m_Capacity - m_Partner.m_CurrentVolume);
        RemoveVolume(transferAmount);
        m_Partner.AddVolume(transferAmount);  
    }
    private void SetDisplay()
    {
        //Debug
        Vector3 ls = m_Display.transform.localScale;
        m_Display.transform.localScale = new Vector3(ls.x, m_CurrentVolume / m_Capacity, ls.z);
        //Debug
    }
}
