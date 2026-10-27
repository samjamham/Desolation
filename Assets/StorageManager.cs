using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public List<Item> m_Items { get; private set; }

    private void Start()
    {
        m_Items = new List<Item>();
    }
    public void AddItems(List<Item> items)
    {
        m_Items.AddRange(items);
    }
    private bool RemoveItem(Item item)
    {
       if (!m_Items.Contains(item))
       {
            return false;
       }
       else
       {
            m_Items.Remove(item);
            return true;
       }
    }

}
