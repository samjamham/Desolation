using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ScavParty : MonoBehaviour
{
    private bool m_WilActivateAtNight;
    [SerializeField] private AStarNavigator m_Navi;
    [SerializeField] private Structs.ScavParty m_ScavParty;
    [SerializeField] private List<Item> m_ScavengedItems;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CyclProgess.AddListener(OnCycleChange);
        m_WilActivateAtNight = false;
    }
    public Structs.ScavParty GetScavParty() 
    { 
        return m_ScavParty; 
    }
    public void OnCycleChange(bool IsNight)
    {
        if (IsNight && !m_WilActivateAtNight)
        {
            //Go into CampMode
            return;
        }
        if(m_Navi.IsAtEndOfPath())
        {
            //Scavenge the local area
            m_ScavengedItems.AddRange(m_Navi.GetCurrentNode().gameObject.GetComponent<ScavLocation>().SearchScavLocation(m_ScavParty));
            //m_ScavengedItems.Sort(); Need to implement IComparable
            return;
        }
        m_Navi.MoveToNextNode();
    }

    public void SetNightTravel(bool Value)
    {
        m_WilActivateAtNight = Value;
    }
    public bool GetNightTravel()
    {
        return m_WilActivateAtNight;
    }
}
