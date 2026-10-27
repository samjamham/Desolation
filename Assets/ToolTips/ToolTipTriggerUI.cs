using UnityEngine.EventSystems;

public class ToolTipTriggerUI : ToolTipTrigger, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        DisplayToolTip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideToolTip();
    }
}
