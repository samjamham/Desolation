using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string header;
    [SerializeField] private string body;
    public void OnPointerEnter(PointerEventData eventData)
    {
        DisplayToolTip(header, body);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        HideToolTip();
    }

    public void OnMouseEnter()
    {
        DisplayToolTip(header, body);
    }
    public void OnMouseExit()
    {
        HideToolTip();
    }

    void DisplayToolTip(string header, string body)
    {
        ToolTipSystem.Show(header, body);
    }
    void HideToolTip()
    {
        ToolTipSystem.Hide();
    }
}
