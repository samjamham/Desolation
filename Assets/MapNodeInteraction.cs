using UnityEngine;

public class MapNodeInteraction : TopDownInteraction
{
    [SerializeField] ToolTipTriggerMap toolTipTriggerMap;
    private AStarNode m_myNode;
    [SerializeField] private AStarNavigator m_myNavigator;
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
    }
    public override void OnMouseEnter()
    {
        toolTipTriggerMap.DebugMouse();
        m_myNavigator?.FindNewPath(m_myNode);
    }
    public void OnMouseExit()
    {
        m_myNavigator?.ClearNewPath();
    }
    public void ChangeNavigator(AStarNavigator Navi)
    {
        m_myNavigator = Navi;
    }

}
