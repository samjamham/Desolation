using UnityEngine;

public class TreatedInteraction : FirstPersonInteraction
{
    [SerializeField] private WaterTower m_WaterTower;
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
        Debug.Log($"Hello I'm Treated I have {m_WaterTower.m_CurrentVolume} out of {m_WaterTower.m_Capacity}: ({m_WaterTower.m_CurrentVolume / m_WaterTower.m_Capacity * 100}%)");
    }
}
