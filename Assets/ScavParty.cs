using System.Collections.Generic;
using System.Linq;
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
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CycleProgess.AddListener(OnCycleChange);
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_DayProgess.AddListener(OnDayChange);
        m_WilActivateAtNight = false;
    }
    private void OnApplicationQuit()
    {
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_CycleProgess.RemoveListener(OnCycleChange);
        GameObject.FindGameObjectWithTag("CycleManager").GetComponent<CycleManager>().m_DayProgess.RemoveListener(OnDayChange);
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
    public void SetNightTravel(bool Value)
    {
        m_WilActivateAtNight = Value;
    }
    public bool GetNightTravel()
    {
        return m_WilActivateAtNight;
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
                m_ScavengedItems.AddRange(SL.SearchScavLocation(m_ScavParty));
            }
            return;
        }
        m_Navi.MoveToNextNode();
    }
    public void OnDayChange()
    {
        IEnumerable<Dweller> NonNull = m_ScavParty.dwellers.Where(x => x != null);
        ConsumeFood(NonNull.Count());
        ConsumeWater(NonNull.Count());
    }

    public void ConsumeFood(int Amount)
    {        
        m_ScavParty.remainingFood -= Amount;

        if (m_ScavParty.remainingFood < 0)
        {
            Debug.Log("Out of food");
            m_ScavParty.remainingFood = 0;
        }
    } 
    public void ConsumeWater(int Amount)
    {
        m_ScavParty.remainingWater -= Amount;

        if (m_ScavParty.remainingWater < 0)
        {
            Debug.Log("Out of water");
            m_ScavParty.remainingWater = 0;
        }
    }

}
