using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapInteractionControls : MonoBehaviour
{
    private ITopDownViewInteractable m_InteractableMouseOver = null;
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
        m_InteractableMouseOver = GetHover(MousePos);
        if (m_InteractableMouseOver is null)
            return true;

        m_InteractableMouseOver.Interact();
        return false;
    }
    public void OnInteractAlt(Vector2 MousePos)
    {
        m_InteractableMouseOver = GetHover(MousePos);
        if (m_InteractableMouseOver is null)
            return;

        m_InteractableMouseOver.InteractAlt();
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
