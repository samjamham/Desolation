using UnityEngine;
using Unity.VisualScripting;

public interface ITopDownViewInteractable
{
    void Interact();
    void InteractAlt();
    bool CanInteract();
}
