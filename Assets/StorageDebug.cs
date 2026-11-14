using System.Collections.Generic;
using UnityEngine;

public class StorageDebug : MonoBehaviour
{
    [SerializeField] private StorageManager m_StorageManager;
    [SerializeField] private List<Item> m_Items;

    private void Start()
    {
        foreach (Item I in m_Items)
        {
            for(int i = 0; i < 5 ; i++)
            {
                m_StorageManager.AddItem(I);
            }
        }
    }
}
