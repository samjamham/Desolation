using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField] private InteractionBox interactionBox;
    [SerializeField] private GameObject PauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InteractionIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputValue value)
    {
        interactionBox.Interact();
    }

    public void OnPause(InputValue value)
    {
        PauseMenu.SetActive(true);
        GetComponent<PlayerInput>().enabled = false;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
