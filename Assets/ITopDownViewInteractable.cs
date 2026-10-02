using UnityEngine;
using Unity.VisualScripting;

public interface ITopDownViewInteractable
{
    void Interact();
    bool CanInteract();
}
