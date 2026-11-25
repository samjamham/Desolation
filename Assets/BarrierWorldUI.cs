using System.Collections.Generic;
using UnityEngine;

public class BarrierWorldUI : MonoBehaviour
{
    [SerializeField] private GameObject m_ItemLayout;
    [SerializeField] private GameObject m_ItemLayoutElementPrefab;
    [SerializeField] private StorageManager m_StorageManager;

    public void ShowUI(List<Craftable.kvp> Items)
    {
        ClearUI();
        foreach (Craftable.kvp item in Items) 
        {
            CreateUIElement(item);
        }
        m_ItemLayout.SetActive(true);
    }
    public void HideUI()
    {
        m_ItemLayout.SetActive(false);
    }

    private void ClearUI()
    {
        for (int i = m_ItemLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_ItemLayout.transform.GetChild(i).gameObject);
        }
    }
    private void CreateUIElement(Craftable.kvp item)
    {
        GameObject prefab = GameObject.Instantiate(m_ItemLayoutElementPrefab, m_ItemLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().SetItem(item.Key);
        prefab.GetComponent<LayoutElementItem>().SetStackSize(item.Value);
        bool ItemInStorage = m_StorageManager.HasItem(new KeyValuePair<Item, int>(item.Key, item.Value));
        if (!ItemInStorage)
        {
            prefab.GetComponent<LayoutElementItem>().SetColour(Color.red);
        }
    }
}
