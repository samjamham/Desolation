using UnityEngine;
using UnityEngine.Events;

public class MapNodeInteraction : TopDownInteraction
{
    [SerializeField] ToolTipTriggerMap m_ToolTipTriggerMap;
    private AStarNode m_MyNode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MyNode = GetComponent<AStarNode>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        TopDownInteraction TDint = m_Controller.GetSelection();
        if (TDint != null && TDint is ScavPartyInteraction)
        {
            TDint.TryGetComponent(out AStarNavigator Navi);
            Navi.UpdateToNewPath();
            m_Controller.SetSelection(null);
            return;
        }
        m_Controller.SetSelection(this);
    }
}
