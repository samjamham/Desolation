using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapInteractionControls : MonoBehaviour
{
    private ITopDownViewInteractable interactableMouseOver = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool OnInteract(Vector2 MousePos)
    {
        interactableMouseOver = GetHover(MousePos);
        if (interactableMouseOver is null)
            return true;

        interactableMouseOver.Interact();
        return false;
    }
    public bool OnInteractAlt(Vector2 MousePos)
    {
        interactableMouseOver = GetHover(MousePos);
        if (interactableMouseOver is null)
            return true;

        interactableMouseOver.InteractAlt();
        return false;
    }
    ITopDownViewInteractable GetHover(Vector2 MousePos)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(MousePos), out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out ITopDownViewInteractable interactable) && interactable.CanInteract())
            {
                return interactable;
            }
        }
        return null;
    }
}
