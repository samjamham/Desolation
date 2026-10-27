using UnityEngine;
using UnityEngine.EventSystems;

public class UIBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] ScryMapDrag m_BlockTarget;
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        m_BlockTarget.SetBlocker(true);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        m_BlockTarget.SetBlocker(false);
    }
}
