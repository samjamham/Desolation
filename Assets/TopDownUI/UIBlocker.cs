using UnityEngine;
using UnityEngine.EventSystems;

public class UIBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] ScryMapDrag m_BlockTarget;
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        m_BlockTarget.SetBlocker(true);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        m_BlockTarget.SetBlocker(false);
    }
}
