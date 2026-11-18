using System.Linq;
using UnityEngine;

public class ScavLocationUI : NodeUI
{
    [SerializeField] private GameObject m_Layout;
    [SerializeField] private GameObject m_LayoutElementPrefab;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayScavLocationUI(Item[] items)
    {
        DisplayUI();
        //clear incase there are any children that shouldn't be there 
        ClearDisplay();
        for (int i = 0; i < items.Count(); i++)
        {
            CreateItemDispaly(items[i]);
        }
    }    
    public void HideScavLocationUI()
    {
        ClearDisplay();
        HideUI();
    }

    private void CreateItemDispaly(Item item)
    {
        GameObject prefab = GameObject.Instantiate(m_LayoutElementPrefab, m_Layout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().ChangeIcon(item.m_Sprite);
    }
    private void ClearDisplay()
    {
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
    }


}
