using UnityEngine;

public class PlayerInteractionBox : MonoBehaviour
{
    private IFirstPersonInteractable m_InteractableInRange = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IFirstPersonInteractable interactable) && interactable.CanInteract())
        {
            m_InteractableInRange?.OnCandidateInteractable(false); //Clear previous candidate so it's impossible to have 2+ candidates active at a time
            interactable.OnCandidateInteractable(true);
            m_InteractableInRange = interactable;
            
            //InteractionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IFirstPersonInteractable interactable) && interactable == m_InteractableInRange)
        {
            m_InteractableInRange = null;
            interactable.OnCandidateInteractable(false);
            //InteractionIcon.SetActive(false);
        }
    }

    public void Interact()
    {
        m_InteractableInRange?.Interact();
    }
}
