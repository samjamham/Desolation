using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ScavLocation : MonoBehaviour
{
    [SerializeField] private Item[] m_Items;
    [SerializeField, Range(0,100)] private float m_Danger;

    public List<Item> SearchScavLocation(Structs.ScavParty Party)
    {
        List<Item> list = new List<Item>();
        //Find items based on whats to find and who the skill of those looking
        foreach(Dweller dweller in Party.dwellers) 
        {
            if (dweller == null) 
                continue;
            if (dweller.m_IsInjured) 
                continue;

            Item FoundItem = m_Items[Random.Range(0, m_Items.Length)];
            dweller.m_IsInjured = InjuryChance(dweller);
            if (dweller.m_IsInjured) //Dwellers can become injured since last time checking
                continue;
            list.Add(FoundItem);
        }
        return list;
    }

    public Item[] GetDiscoverableItems()
    { 
        return m_Items; 
    }
    private bool InjuryChance(Dweller dweller)
    {
        //float InjureChance = Random.Range(0, m_Danger);
        //return (dweller.m_Stat_DangerCounter < InjureChance);


        float chance = Mathf.Max(0, m_Danger - dweller.m_Stat_DangerCounter);
        return (chance > Random.Range(0, 100));
    }
}
