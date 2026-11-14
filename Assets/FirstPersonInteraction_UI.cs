using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonInteraction_UI : FirstPersonInteraction
{
    [SerializeField] FirstPersonInteractableUI m_UserInterface;
    [SerializeField] GameObject m_Player;

    protected void DisplayUI()
    {
        m_UserInterface.DisplayUI();
        m_Player.GetComponent<PlayerInput>().enabled = false;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
