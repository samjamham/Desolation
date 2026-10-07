using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTriggerUI : ToolTipTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        DisplayToolTip();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        delay = false;
        HideToolTip();
    }
}
