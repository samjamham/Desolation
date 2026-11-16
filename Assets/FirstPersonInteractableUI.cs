using UnityEngine;
using UnityEngine.Events;

public class FirstPersonInteractableUI : MonoBehaviour
{
    [SerializeField] protected UnityEvent m_DisplayEvent;
    [SerializeField] protected UnityEvent m_HideEvent;
    public virtual void DisplayUI()
    {
    }
    public virtual void HideUI()
    {
    }
}
