using System.Collections.Generic;
using UnityEngine;

public class ScavLocation : MonoBehaviour
{
    [SerializeField] private Item[] m_Items;

    public List<Item> SearchScavLocation(Structs.ScavParty Party)
    {
        List<Item> list = new List<Item>();
        //Find items based on whats to find and who the skill of those looking
        foreach(Dweller dweller in Party.dwellers) 
        {

            list.Add(m_Items[Random.Range(0, m_Items.Length)]);
        }

        return list;
    }

    public Item[] GetFoundItems()
    { 
        return m_Items; 
    }
}
