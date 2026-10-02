using UnityEngine;

public class PlayerInteractionBox : MonoBehaviour
{
    private IFirstPersonInteractable interactableInRange = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IFirstPersonInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            //InteractionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IFirstPersonInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            //InteractionIcon.SetActive(false);
        }
    }

    public void Interact()
    {
        interactableInRange?.Interact();
    }
}
