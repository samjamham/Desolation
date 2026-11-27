using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DwellerManager : MonoBehaviour
{
    [field: SerializeField] public List<Dweller> m_DwellerList { get; private set; }

    private void Awake()
    {
        m_DwellerList = new List<Dweller>();
        foreach(Dweller D in GetComponent<DEBUGDwellerList>().m_Dwellers)
        {
            Dweller SO = Dweller.Instantiate(D);
            m_DwellerList.Add(SO);
        }
    }
    private void OnApplicationQuit()
    {
        foreach (Dweller D in m_DwellerList)
        {
            Destroy(D);
        }
    }

    void AddDweller(Dweller InDweller)
    {
        if (m_DwellerList.Contains(InDweller))
            return;
        m_DwellerList.Add(InDweller);
    }
    bool RemoveDweller(Dweller InDweller)
    {
        if (!m_DwellerList.Contains(InDweller))
            return false;
        m_DwellerList.Remove(InDweller);
        return true;
    }
    void OnCycleChange()
    {

    }    
    void OnDayChange()
    {

    }
}
