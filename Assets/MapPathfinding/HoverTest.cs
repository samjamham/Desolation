using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.InputSystem;

public class HoverTest : MonoBehaviour
{
    private AStarNode m_MyNode;
    [SerializeField] private AStarNavigator m_MyNavigator;


    private void Start()
    {
        m_MyNode = GetComponent<AStarNode>();
    }

    public void OnMouseEnter()
    {
        m_MyNavigator?.FindPotenalPath(m_MyNode);
    }
    public void OnMouseExit()
    {
        m_MyNavigator?.ClearPotentalPath();
    }
    public void ChangeNavigator(AStarNavigator Navi)
    {
        m_MyNavigator = Navi;
    }

}
