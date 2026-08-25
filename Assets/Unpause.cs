using UnityEngine;
using UnityEngine.InputSystem;

public class Unpause : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnUnpause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.GetComponent<PlayerInput>().enabled = true;
    }
}
