using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private TopDownInteraction m_CurrentSelection;
    [SerializeField] private TopDownInteraction m_CurrentHover;
    private PlayerManager.Playmode m_playmode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
