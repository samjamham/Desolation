using UnityEngine;
using UnityEngine.UI;

public class ScavPartyUI : TopDownUI
{   [SerializeField] private GameObject m_Layout;
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private Toggle m_Toggle;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavPartyUI(Structs.ScavParty ScavParty, bool NightTravel)
    {
        DisplayUI();
        m_Toggle.SetIsOnWithoutNotify(NightTravel);       
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 3; i++)
        {
            CreatePartyMemberDispaly(ScavParty.dwellers[i]);
        }

    }
    public void HideScavPartyUI()
    {
        HideUI();
    }
    private void CreatePartyMemberDispaly(Dweller Dweller)
    {
        GameObject prefab = GameObject.Instantiate(m_Prefab, m_Layout.transform);
        prefab.GetComponent<UnityEngine.UI.Image>().sprite = Dweller.m_Sprite;
    }
    
    public void SetNightTravel()
    {
        bool value = m_Toggle.isOn;
        m_MapController?.SetNightTravel(value);
    }    
}
