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
        Debug.Log($"Hi im {this}");
    }
    public override void OnMouseEnter()
    {
        toolTipTriggerMap.HoverTriggerEnter();
    }
    public override void OnMouseExit()
    {
        toolTipTriggerMap.HoverTriggerExit();
    }
}
