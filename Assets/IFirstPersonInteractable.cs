using UnityEngine;
using Unity.VisualScripting;

public interface IFirstPersonInteractable 
{
    void Interact();    
    bool CanInteract();
    void SetInteract(bool value);
    void OnCandidateInteractable(bool isCandidate);
}
