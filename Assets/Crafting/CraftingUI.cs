using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftingUI : FirstPersonInteractableUI
{
    private Craftable m_CurrentCraftable;
    [SerializeField] private StorageManager m_StorageManager;
    
    [Header("Left Side")]
    [SerializeField] private GameObject m_CraftableLayout;
    [SerializeField] private GameObject m_CraftableLayoutElementPrefab;    
    [SerializeField] private ToggleGroup m_toogleGroup;

    [Header("Right Side")]
    [SerializeField] private Image m_CraftableImage;
    [SerializeField] private Button m_CraftButton;
    [SerializeField] private GameObject m_ItemLayout;
    [SerializeField] private GameObject m_ItemLayoutElementPrefab;

    [Header("")]
    [SerializeField] private List<Craftable> m_Craftables;
    public override void DisplayUI()
    {        
        m_CraftButton.interactable = false;
        m_DisplayEvent.Invoke();
        ClearDisplay();

        foreach (Craftable item in m_Craftables)
        {
            CreateCraftableDisplay(item);
        }
    }
    public override void HideUI()
    {
        m_HideEvent.Invoke();
        ClearDisplay();
    }
    public void SetCraftables(List<Craftable> CraftableArray)
    {
        m_Craftables = CraftableArray;
    }
    private void CreateCraftableDisplay(Craftable item)
    {
        GameObject prefab = GameObject.Instantiate(m_CraftableLayoutElementPrefab, m_CraftableLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().SetItem(item);
        prefab.GetComponent<Toggle>().group = m_toogleGroup;
        prefab.GetComponent<Toggle>().onValueChanged.AddListener(delegate { this.ClearCraftingDisplay(); });
        prefab.GetComponent<Toggle>().onValueChanged.AddListener(delegate { this.CreateCraftingDisplay(item); });
        prefab.GetComponent<ToolTipTriggerUI>().SetHeader(item.name);
        prefab.GetComponent<ToolTipTriggerUI>().SetBody("");
    }
    private void CreateCraftingDisplay(Craftable item)
    {
        if (item is null)
            return;
        m_CraftButton.interactable = true;
        foreach (Craftable.kvp kvp in item.ReqIngredient)
        {
            if (!CreateCraftingDisplayReqIngredients(kvp))
            {
                m_CraftButton.interactable = false;
            }
        }
        m_CraftableImage.sprite = item.m_Sprite;
        //m_CraftButton.onClick.AddListener(delegate { CRAFT(); }) ;
        m_CurrentCraftable = item;
    }
    private bool CreateCraftingDisplayReqIngredients(Craftable.kvp item)
    {
        GameObject prefab = GameObject.Instantiate(m_ItemLayoutElementPrefab, m_ItemLayout.transform); //Create a layout element as a child of the layout group. The group will automatically resize to fit
        prefab.GetComponent<LayoutElementItem>().SetItem(item.Key);       
        prefab.GetComponent<LayoutElementItem>().SetStackSize(item.Value); 
        prefab.GetComponent<ToolTipTriggerUI>().SetHeader(item.Key.name);
        prefab.GetComponent<ToolTipTriggerUI>().SetBody("");
        bool ItemInStorage = m_StorageManager.HasItem(new KeyValuePair<Item, int>(item.Key, item.Value));
        if (!ItemInStorage)
        {
            prefab.GetComponent<LayoutElementItem>().SetColour(Color.red);
        }
        return ItemInStorage;

    }

    private void ClearDisplay()
    {
        for (int i = m_CraftableLayout.transform.childCount - 1; i >= 0; i--)
        {
            m_CraftableLayout.transform.GetChild(i).GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
            Destroy(m_CraftableLayout.transform.GetChild(i).gameObject);
        }
        ClearCraftingDisplay();
    }
    private void ClearCraftingDisplay()
    {
        for (int i = m_ItemLayout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_ItemLayout.transform.GetChild(i).gameObject);
        }
        m_CraftableImage.sprite = null;
        m_CraftButton.onClick.RemoveAllListeners();
        m_CurrentCraftable = null;
    }

    public void CRAFT() //ew. me no like
    {
        List<KeyValuePair<Item, int>> tempkvp = new List<KeyValuePair<Item, int>>();
        foreach(Craftable.kvp kvp in m_CurrentCraftable.ReqIngredient)
        {
            KeyValuePair<Item, int> KVP = new KeyValuePair<Item, int>(kvp.Key, kvp.Value);
            tempkvp.Add(KVP);
        }
        m_StorageManager.RemoveItems(tempkvp);
        m_StorageManager.AddItem(m_CurrentCraftable);
        Craftable temp = m_CurrentCraftable;
        ClearCraftingDisplay();
        CreateCraftingDisplay(temp);
    }
}