using UnityEngine;
using UnityEngine.Events;

public class MapNodeInteraction : TopDownInteraction
{
    [SerializeField] ToolTipTriggerMap toolTipTriggerMap;
    private AStarNode m_myNode;
    [SerializeField] private AStarNavigator m_myNavigator;
    [SerializeField] UnityEvent Event;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_myNode = GetComponent<AStarNode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        Debug.Log($"Hi im {this}");
        Event.Invoke();
    }
    public override void OnMouseEnter()
    {
        toolTipTriggerMap.HoverTriggerEnter();
        m_myNavigator?.FindPotenalPath(m_myNode);
    }
    public override void OnMouseExit()
    {
        m_myNavigator?.ClearPotentalPath();
        toolTipTriggerMap.HoverTriggerExit();
    }
    public void ChangeNavigator(AStarNavigator Navi)
    {
        m_myNavigator = Navi;
    }

}
