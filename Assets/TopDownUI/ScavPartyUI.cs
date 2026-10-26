using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScavPartyUI : TopDownUI
{   [SerializeField] private GameObject m_Layout;
    [SerializeField] private GameObject m_LayoutElementPrefab;
    [SerializeField] private Toggle m_Toggle;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavPartyUI(Structs.ScavParty ScavParty, bool NightTravel)
    {
        DisplayUI();
        m_Toggle.SetIsOnWithoutNotify(NightTravel);       
        ClearDisplay(); //clear incase there are any children that shouldn't be there 
        for (int i = 0; i < ScavParty.dwellers.Count(); i++)
        {
            CreatePartyMemberDispaly(ScavParty.dwellers[i]);
        }
    }
    public void HideScavPartyUI()
    {
        ClearDisplay();
        HideUI();
    }
    private void CreatePartyMemberDispaly(Dweller Dweller)
    {
        GameObject prefab = GameObject.Instantiate(m_LayoutElementPrefab, m_Layout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<UnityEngine.UI.Image>().sprite = Dweller.m_Sprite;
    }
    private void ClearDisplay()
    {
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
    }
    
    public void SetNightTravel()
    {
        bool value = m_Toggle.isOn;
        m_MapController?.SetNightTravel(value);
    }    
}
