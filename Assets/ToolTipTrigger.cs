using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected string header;
    [SerializeField] protected string body;
    [SerializeField, Range(0, 1)] protected float DisplayDelay = 0;
    protected bool delay;
    
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //DisplayToolTip(header, body);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //delay = false;
        //HideToolTip();
    }

    public virtual void OnMouseEnter()
    {
        //if (PlayerManager.playmode != PlayerManager.Playmode.TopDown)
        //{
        //    return; 
        //}
        //if ((Mathf.Abs(transform.position.x) > 0.95f) && (Mathf.Abs(transform.position.z) > 0.95f))
        //{
        //    return;
        //}
        //DisplayToolTip(header, body);
    }
    public virtual void OnMouseExit()
    {
        //delay = false;
        //HideToolTip();
    }

    protected void DisplayToolTip(string header, string body)
    {
        //ToolTipSystem.Show(header, body);
        delay = true;
        StartCoroutine(DisplayOnDelay(DisplayDelay));
    }
    protected void HideToolTip()
    {
        ToolTipSystem.Hide();
    }
    IEnumerator DisplayOnDelay(float value)
    {
        yield return new WaitForSeconds(value);
        if (delay)
        {
            ToolTipSystem.Show(header, body);
        }
    }
}
