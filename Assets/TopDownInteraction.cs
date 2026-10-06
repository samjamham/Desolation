using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TopDownInteraction : MonoBehaviour, ITopDownViewInteractable
{
    [SerializeField] private bool canInteract;
    [SerializeField] protected MapController m_Controller;
    
    public virtual bool CanInteract()
    {
        return canInteract;
    }

    public virtual void OnMouseEnter()
    {

    } 
    public virtual void OnMouseExit()
    {

    }
    public virtual void Interact()
    {

    }

    public virtual void GetSelected()
    {

    }
    public virtual void GetDeselected()
    {
    }
}
