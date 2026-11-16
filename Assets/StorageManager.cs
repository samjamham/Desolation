using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Structs;

public class StorageManager : MonoBehaviour
{
    public SortedDictionary<Item,int> m_Items { get; private set; }

    private void Awake()
    {
        m_Items = new SortedDictionary<Item, int>();
    }
    public void AddItems(List<Item> items)
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
    }
    public void AddItem(Item item)
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

    public void RemoveItems(List<KeyValuePair<Item,int>> items)
    {
        foreach (KeyValuePair<Item, int> item in items)
        {
            for(int i = 0; i <item.Value; i++)
            {
                RemoveItem(item.Key);
            }

        }
    }
    private bool RemoveItem(Item item)
    {
        m_Items[item]--;
        if (m_Items[item] == 0)
        {
            m_Items.Remove(item);
        }
        return false;
    }
}
