using UnityEngine;

public class MapNodeInteraction : TopDownInteraction
{
    [SerializeField] private ToolTipTriggerMap m_ToolTipTriggerMap;
    protected AStarNode m_MyNode;
    protected ScavLocationUI m_LocationUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MyNode = GetComponent<AStarNode>();
        m_LocationUI = GameObject.FindGameObjectWithTag("ScavLocationUI").GetComponent<ScavLocationUI>();
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
    public override void InteractAlt()
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
        m_LocationUI?.DisplayScavLocationUI(gameObject.GetComponent<ScavLocation>().GetFoundItems());
    }
    public override void OnDeselected()
    {
        m_LocationUI?.HideScavLocationUI();
    }
}
