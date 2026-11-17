using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FirstPersonInteraction : MonoBehaviour, IFirstPersonInteractable
{
    [SerializeField] private bool canInteract;
    public virtual void Interact()
    {

    }
    public virtual bool CanInteract()
    {
        return canInteract;
    }
    public void SetInteract(bool value)
    {
        canInteract = value;
    }
}
