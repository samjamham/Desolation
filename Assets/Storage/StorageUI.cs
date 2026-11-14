using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static Structs;

public class StorageUI : FirstPersonInteractableUI
{
    [SerializeField] private GameObject m_ItemLayout;
    [SerializeField] private GameObject m_ItemLayoutElementPrefab;
    [SerializeField] private StorageManager m_StorageManager;
    public override void DisplayUI()
    {
        m_DisplayEvent.Invoke();
        ClearDisplay();
        foreach (KeyValuePair<Item,int> item in m_StorageManager.m_Items)
        {
            CreateItemDisplay(item);
        }
    }
    public void HideStorageUI()
    {
        m_HideEvent.Invoke();
    }

    private void CreateItemDisplay(KeyValuePair<Item, int> item)
    {
        GameObject prefab = GameObject.Instantiate(m_ItemLayoutElementPrefab, m_ItemLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().ChangeIcon(item.Key.m_Sprite);
        prefab.GetComponent<LayoutElementItem>().SetStackSize(item.Value);
        prefab.GetComponent<ToolTipTriggerUI>().SetHeader(item.Key.name);
        prefab.GetComponent<ToolTipTriggerUI>().SetBody("");
    }
    private void ClearDisplay()
    {
        for (int i = m_ItemLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_ItemLayout.transform.GetChild(i).gameObject);
        }
    }
}
