using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Structs;

public class StorageManager : MonoBehaviour
{
    public SortedDictionary<Item,int> m_Items { get; private set; }

    private void Start()
    {
        m_Items = new SortedDictionary<Item, int>();
    }
    public void AddItems(List<Item> items)
    {
        foreach(Item item in items)
        {
            if (m_Items.ContainsKey(item))
            {
                m_Items[item]++;
            }
            else
            {
                m_Items.Add(item, 1);
            }
        }
    }
    private bool RemoveItem(Item item)
    { 
        return false;
    }
}
