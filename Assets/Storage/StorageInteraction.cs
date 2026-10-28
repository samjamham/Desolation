using UnityEngine;
using UnityEngine.InputSystem;

public class StorageInteraction : FirstPersonInteraction
{
    [SerializeField] StorageUI m_StorageUI;
    [SerializeField] GameObject m_Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        Debug.Log("Hi I'm a Storage");
        m_StorageUI.DisplayStorageUI();
        m_Player.GetComponent<PlayerInput>().enabled = false;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
