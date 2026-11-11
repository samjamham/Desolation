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
        Toggle[] index = m_ToggleGroup.ActiveToggles().ToArray<Toggle>();
        if (index.Count() == 0)
        { 
            CloseDwellerMenu();
            return;
        }

        m_ToggleSelection = value;
        m_DwellerSelectionMenu.SetActive(true);

        ClearLayoutDisplay();

        if (m_DwellerSelection[value] is not null)
            CreateLayoutDisplay(null);

        foreach (Dweller D in gameObject.GetComponent<DEBUGDwellerList>().m_Dwellers)
        {
            if (m_DwellerSelection.Contains(D))
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
            return; 
        }
        m_ToggleGroup.GetFirstActiveToggle().transform.GetChild(0).GetComponent<Image>().sprite = dweller.m_Sprite;
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
        if (D is null)
        {
            prefab.GetComponent<Image>().sprite = m_DefualtSpirte;
            return;
        }

        prefab.GetComponent<Image>().sprite = D.m_Sprite;
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
        SP.remainingFood = (int)m_FoodSlider.value;
        SP.remainingWater = (int)m_WaterSlider.value;

        m_ScryMap.CreateScavParty(SP);
        m_HomeNodeUI.DeseletInteractable();
    }
}
