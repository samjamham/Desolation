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
        m_myNavigator?.FindPotenalPath(m_myNode);
    }
    public void OnMouseExit()
    {
        m_myNavigator?.ClearPotentalPath();
    }
    public void ChangeNavigator(AStarNavigator Navi)
    {
        m_myNavigator = Navi;
    }

}
