using UnityEngine;

public class MapNodeInteraction : TopDownInteraction
{
    [SerializeField] protected ToolTipTriggerMap m_ToolTipTriggerMap;
    protected AStarNode m_MyNode;
    protected NodeUI m_LocationUI;
    protected void NodeSetup()
    {
        m_MyNode = GetComponent<AStarNode>();
        FindController();
    }
    public AStarNode GetNode()
    { 
        return m_MyNode; 
    }

    public override void OnMouseEnter()
    {
        m_Controller.SetHovered(this);
        m_ToolTipTriggerMap.HoverTriggerEnter();

    }
    public override void OnMouseExit()
    {
        m_Controller.SetHovered(null);
        m_ToolTipTriggerMap.HoverTriggerExit();
    }    
    public override void Interact()
    {
        m_Controller.SetSelection(this);
    }
    public override void InteractAlt() //RightClick. Only used when current selection is a ScavParty
    {
        TopDownInteraction TDint = m_Controller.GetSelection();
        if (TDint is not null && TDint is ScavPartyInteraction)
        {
            TDint.TryGetComponent(out AStarNavigator Navi);
            Navi.UpdateToNewPath();
            m_Controller.SetSelection(null);
            return;
        }
    }
    public override void OnSelected()
    {
        m_LocationUI?.DisplayUI();
    }
    public override void OnDeselected()
    {
        m_LocationUI?.HideUI();
    }
}
