using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DwellerManager : MonoBehaviour
{
    public List<Dweller> m_DwellerList { get; private set; }

    private void Awake()
    {
        m_DwellerList = GetComponent<DEBUGDwellerList>().m_Dwellers;

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
}
