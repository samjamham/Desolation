using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private TopDownInteraction m_CurrentSelection;
    [SerializeField] private TopDownInteraction m_CurrentHover;
    [SerializeField] private GameObject ScavPartyPrefab;
    [SerializeField] private AStarNode HomeNode;
    private PlayerManager.Playmode m_playmode;
    void Start()
    {
        
    }
    public void EnterTopDown()
    {
        m_playmode = PlayerManager.Playmode.TopDown;
    }
    public void ReturnToPlayer()
    {
        SetSelection(null);
        SetHovered(null);
        m_playmode = PlayerManager.Playmode.FirstPerson;
    }

    public void SetSelection(TopDownInteraction Interactable)
    {
        if (m_playmode == PlayerManager.Playmode.FirstPerson)
            return;
        m_CurrentSelection?.OnDeselected();
        Interactable?.OnSelected();
        m_CurrentSelection = Interactable;
    }
    public TopDownInteraction GetSelection()
    {
        return m_CurrentSelection;
    }
    public void SetHovered(TopDownInteraction Interactable)
    {
        if (m_playmode == PlayerManager.Playmode.FirstPerson)
            return;
        m_CurrentHover = Interactable;
        if (m_CurrentSelection == null)
            return;
        Navi_NodeHover();
    }
    public TopDownInteraction GetHovered()
    {
        return m_CurrentHover;
    }

    void Navi_NodeHover()
    {
        if (m_CurrentHover == null && m_CurrentSelection is ScavPartyInteraction)
        {
            m_CurrentSelection.GetComponent<AStarNavigator>().ClearPotentalPath();
        }
        else if(m_CurrentHover is MapNodeInteraction && m_CurrentSelection is ScavPartyInteraction)
        {
            m_CurrentSelection.GetComponent<AStarNavigator>().FindPotenalPath(m_CurrentHover.GetComponent<MapNodeInteraction>().GetNode());
        }
    }    

    public void SetNightTravel(bool value)
    {
        if (m_CurrentSelection is not ScavPartyInteraction)
        {
            return;
        }
        m_CurrentSelection.gameObject.GetComponent<ScavParty>().SetNightTravel(value);
    }
    public void ReturnHome(ScryMapDrag SMD)
    {
        if (m_CurrentSelection is not ScavPartyInteraction)
        {
            return;
        }
        GameObject ToDelete = m_CurrentSelection.gameObject;
        SMD.Additems(m_CurrentSelection.GetComponent<ScavParty>().GetScavItems());
        foreach(Dweller dweller in  m_CurrentSelection.GetComponent<ScavParty>().GetScavParty().dwellers)
        {
            if (dweller is not  null) 
            {
                dweller.m_IsActive = false;
            }
        }
        SetSelection(null);
        SetHovered(null);
        Destroy(ToDelete);
    }
    public void CreateScavParty(Structs.ScavParty SP)
    {
        GameObject prefab = Instantiate(ScavPartyPrefab, transform.GetChild(0));
        prefab.transform.position = HomeNode.transform.position;
        prefab.GetComponent<AStarNavigator>().FindStartPath(HomeNode, HomeNode);
        prefab.GetComponent<ScavParty>().SetScavParty(SP);
        prefab.GetComponent<ScavParty>().m_homeNode = HomeNode;
        prefab.GetComponent<ToolTipTriggerMap>().SetHeader("Scav Party");
        prefab.GetComponent<ToolTipTriggerMap>().SetBody("DEBUG: ADD THEIR NAMES");
    }
}
