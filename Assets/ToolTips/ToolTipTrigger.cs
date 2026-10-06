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

    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {

    }

    public virtual void OnMouseEnter()
    {

    }
    public virtual void OnMouseExit()
    {

    }

    protected void DisplayToolTip(string header, string body)
    {
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
