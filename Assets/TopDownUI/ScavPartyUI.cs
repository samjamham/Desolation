using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScavPartyUI : TopDownUI
{   
    [SerializeField] private GameObject m_DwellerLayout;
    [SerializeField] private GameObject m_DwellerLayoutElementPrefab;    
    [SerializeField] private GameObject m_ItemLayout;
    [SerializeField] private GameObject m_ItemLayoutElementPrefab;
    [SerializeField] private Toggle m_Toggle;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavPartyUI(Structs.ScavParty ScavParty, bool NightTravel, List<Item> items)
    {
        DisplayUI();
        m_Toggle.SetIsOnWithoutNotify(NightTravel);       
        ClearDisplay(); //clear incase there are any children that shouldn't be there 
        for (int i = 0; i < ScavParty.dwellers.Count(); i++)
        {
            CreatePartyMemberDispaly(ScavParty.dwellers[i]);
        }
        for (int i = 0; i < items.Count(); i++)
        {
            CreateItemDispaly(items[i]);
        }
    }
    public void HideScavPartyUI()
    {
        ClearDisplay();
        HideUI();
    }
    private void CreatePartyMemberDispaly(Dweller Dweller)
    {
        GameObject prefab = GameObject.Instantiate(m_DwellerLayoutElementPrefab, m_DwellerLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<UnityEngine.UI.Image>().sprite = Dweller.m_Sprite;
        prefab.GetComponent<ToolTipTriggerUI>().SetHeader(Dweller.name);
        prefab.GetComponent<ToolTipTriggerUI>().SetBody("");
    }
    private void CreateItemDispaly(Item item)
    {
        GameObject prefab = GameObject.Instantiate(m_ItemLayoutElementPrefab, m_ItemLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().ChangeIcon(item.m_Sprite);
    }
    private void ClearDisplay()
    {
        for (int i = m_DwellerLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_DwellerLayout.transform.GetChild(i).gameObject);
        }
        for (int i = m_ItemLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_ItemLayout.transform.GetChild(i).gameObject);
        }
    }
    
    public void SetNightTravel()
    {
        bool value = m_Toggle.isOn;
        m_MapController?.SetNightTravel(value);
    }    
}
