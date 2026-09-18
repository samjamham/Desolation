using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.InputSystem;

public class HoverTest : MonoBehaviour
{
    private AStarNode m_myNode;
    [SerializeField] private AStarNavigator m_myNavigator;


    private void Start()
    {
        m_myNode = GetComponent<AStarNode>();
    }

    public void OnMouseEnter()
    {
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
