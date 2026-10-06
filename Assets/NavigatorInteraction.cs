using UnityEngine;

public class NavigatorInteraction : TopDownInteraction
{
    [SerializeField] ToolTipTriggerMap toolTipTriggerMap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        m_Controller.SetSelection(this);
    }
    public override void OnMouseEnter()
    {
        m_Controller.SetHovered(this);
        toolTipTriggerMap.HoverTriggerEnter();

    }
    public override void OnMouseExit()
    {
        m_Controller.SetHovered(null);
        toolTipTriggerMap.HoverTriggerExit();
    }
}
