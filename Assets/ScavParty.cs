using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ScavParty : MonoBehaviour
{
    [SerializeField] private Structs.ScavParty m_ScavParty;
    [SerializeField] private AStarNavigator m_Navi;
    private bool m_WillTravelAtNight;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CyclProgess.AddListener(OnCycleChange);
        m_WillTravelAtNight = false;
    }
    public Structs.ScavParty GetScavParty() 
    { 
        return m_ScavParty; 
    }
    public void OnCycleChange(bool IsNight)
    {
        if (IsNight && !m_WillTravelAtNight)
        {
            //Do Scavenging 
            return;
        }
        m_Navi.OnCycleChange(IsNight);
    }

    public void SetNightTravel(bool Value)
    {
        m_WillTravelAtNight = Value;
    }
    public bool GetNightTravel()
    {
        return m_WillTravelAtNight;
    }
}
