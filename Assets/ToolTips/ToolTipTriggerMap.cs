using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTriggerMap : ToolTipTrigger
{
    //public override void OnMouseEnter()
    public void DebugMouse()
    {
        if (PlayerManager.playmode != PlayerManager.Playmode.TopDown || (Mathf.Abs(transform.position.x) > 0.95f) || (Mathf.Abs(transform.position.z) > 0.95f))
        {
            return;
        }
        DisplayToolTip(header, body);
    }
    public override void OnMouseExit()
    {
        delay = false;
        HideToolTip();
    }
}
