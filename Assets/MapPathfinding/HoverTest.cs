using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.InputSystem;

public class HoverTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private AStarNode m_myNode;
    [SerializeField] private AStarNavigator m_myNavigator;


    private void Start()
    {
        m_myNode = GetComponent<AStarNode>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MEn();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MEx();
    }

    public void OnMouseEnter()
    {
        MEn();
    }
    public void OnMouseExit()
    {
        MEx();
    }
    private void MEn()
    {
        m_myNavigator?.FindNewPath(m_myNode);
    }
    private void MEx()
    {
        m_myNavigator?.ClearNewPath();
    }
    public void ChangeNavigator(AStarNavigator Navi)
    {
        m_myNavigator = Navi;
    }

}
