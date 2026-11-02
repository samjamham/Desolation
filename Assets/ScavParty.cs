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
    public AStarNode m_homeNode;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CyclProgess.AddListener(OnCycleChange);
        m_WilActivateAtNight = false;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CyclProgess.RemoveListener(OnCycleChange);
    }
    public Structs.ScavParty GetScavParty() 
    { 
        return m_ScavParty; 
    }
    public void SetScavParty(Structs.ScavParty SP) 
    {
        m_ScavParty = SP; 
    }
    public List<Item> GetScavItems()
    {
        return m_ScavengedItems;
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
            if (m_Navi.GetCurrentNode().gameObject.TryGetComponent(out ScavLocation SL))
            {
                //Scavenge the local area
                m_ScavengedItems.AddRange(m_Navi.GetCurrentNode().gameObject.GetComponent<ScavLocation>().SearchScavLocation(m_ScavParty));
            }
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
