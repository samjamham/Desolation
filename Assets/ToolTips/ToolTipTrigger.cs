using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour
{
    [SerializeField] protected string m_Header;
    [SerializeField] protected string m_Body;
    [SerializeField, Range(0, 1)] protected float m_DisplayDelay = 0;
    protected bool m_Delay;

    protected void DisplayToolTip()
    {
        m_Delay = true;
        StartCoroutine(DisplayOnDelay(m_DisplayDelay));
    }
    protected void HideToolTip()
    {
        m_Delay = false;
        ToolTipSystem.Hide();
    }
    IEnumerator DisplayOnDelay(float value)
    {
        yield return new WaitForSeconds(value);
        if (m_Delay)
        {
            ToolTipSystem.Show(m_Header, m_Body);
        }
    }

    public void SetHeader(string value)
    {
        m_Header = value;
    }    
    public void SetBody(string value)
    {
        m_Body = value;
    }

}
