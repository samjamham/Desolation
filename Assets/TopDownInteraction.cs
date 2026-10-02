using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TopDownInteraction : MonoBehaviour, ITopDownViewInteractable
{
    [SerializeField] private bool canInteract;
    public virtual void Interact()
    {

    }
    public virtual bool CanInteract()
    {
        return canInteract;
    }

    public virtual void OnMouseEnter()
    {

    }
}
