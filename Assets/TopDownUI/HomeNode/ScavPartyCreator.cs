using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScavPartyCreator : MonoBehaviour
{
    [SerializeField] private ScryMapDrag m_ScryMap;
    [SerializeField] private HomeNodeUI m_HomeNodeUI;   
    [SerializeField] private GameObject m_DwellerSelectionMenu;
    [SerializeField] private GameObject m_DwellerLayoutPrefab;
    [SerializeField] ToggleGroup m_ToggleGroup;
    [SerializeField] private Sprite m_DefualtSpirte;
    [SerializeField] private DwellerManager m_DwellerManager;

    [Header("ScavPartyViewerForDebug")]
    [SerializeField] private Dweller[] m_DwellerSelection;
    [SerializeField] private Slider m_FoodSlider;
    [SerializeField] private Slider m_WaterSlider;
    private int m_ToggleSelection; 

    private void Awake()
    {
        m_DwellerSelection = new Dweller[4];
    }    

    public void OpenDwellerMenu(int value)
    {
        List<Toggle> index = m_ToggleGroup.ActiveToggles().ToList();
        if (index.Count() == 0)
        { 
            CloseDwellerMenu();
            return;
        }

        m_ToggleSelection = value;
        m_DwellerSelectionMenu.SetActive(true);

        ClearLayoutDisplay();

        if (m_DwellerSelection[value] is not null) //Allow player to set the current selection to null if a Dweller is already selected in that slot. Effectively acting as a "clear" option.
            CreateLayoutDisplay(null);

        foreach (Dweller D in m_DwellerManager.m_DwellerList)
        {
            if (m_DwellerSelection.Contains(D) || D.m_IsActive)
                continue;
            CreateLayoutDisplay(D);
        }
    }   
    
    public void CloseDwellerMenu()
    {
        m_DwellerSelectionMenu.SetActive(false);
        foreach (Transform child in m_ToggleGroup.transform)
        {
            child.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
            m_ToggleSelection = -1;
        }
    }
    public void SetDweller(Dweller dweller)
    {
        m_DwellerSelection[m_ToggleSelection] = dweller;
        if (dweller is null)
        {
            m_ToggleGroup.GetFirstActiveToggle().transform.GetChild(0).GetComponent<Image>().sprite = m_DefualtSpirte;
            m_ToggleGroup.GetFirstActiveToggle().GetComponent<ToolTipTriggerUI>().SetHeader("");
            return; 
        }
        m_ToggleGroup.GetFirstActiveToggle().transform.GetChild(0).GetComponent<Image>().sprite = dweller.m_Sprite;
        m_ToggleGroup.GetFirstActiveToggle().GetComponent<ToolTipTriggerUI>().SetHeader(dweller.name);
    }
    public void ClearDwellers()
    {
        Array.Clear(m_DwellerSelection, 0, m_DwellerSelection.Length);
    }

    private void CreateLayoutDisplay(Dweller D)
    {
        GameObject prefab = GameObject.Instantiate(m_DwellerLayoutPrefab, m_DwellerSelectionMenu.transform);

        prefab.GetComponent<Button>().onClick.AddListener(delegate { SetDweller(D); });
        prefab.GetComponent<Button>().onClick.AddListener(delegate { CloseDwellerMenu(); }) ;
        prefab.GetComponent<Button>().onClick.AddListener(delegate { ToolTipSystem.Hide(); }) ;
        
        if (D is null) //null for when we want to clear a potential party member
        {
            prefab.GetComponent<Image>().sprite = m_DefualtSpirte;
            prefab.GetComponent<ToolTipTriggerUI>().SetHeader("Remove");
            return;
        }
        if (D.m_IsInjured)
        {
            prefab.GetComponent<Button>().interactable = false;
        }
        prefab.GetComponent<Image>().sprite = D.m_Sprite;
        prefab.GetComponent<ToolTipTriggerUI>().SetHeader(D.name);
    }

    private void ClearLayoutDisplay()
    {
        for (int i = m_DwellerSelectionMenu.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_DwellerSelectionMenu.transform.GetChild(i).gameObject);
        }
    }
    public void CreateScavParty()
    {
        Structs.ScavParty SP = new Structs.ScavParty();

        IEnumerable<Dweller> NonNull = m_DwellerSelection.Where(x => x != null);
        if (NonNull.Count() == 0)
            return;
        SP.dwellers = NonNull.ToArray();
        foreach(Dweller dweller in SP.dwellers)
        {
            dweller.m_IsActive = true;
        }
        SP.remainingFood = (int)m_FoodSlider.value; //Remove from water
        SP.remainingWater = (int)m_WaterSlider.value; //Remove from Food

        m_ScryMap.CreateScavParty(SP);
        m_HomeNodeUI.DeseletInteractable();
    }
}
