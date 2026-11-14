using UnityEngine;
using UnityEngine.InputSystem;

public class StorageInteraction : FirstPersonInteraction_UI
{
    public override void Interact()
    {
        Debug.Log("Hi I'm a Storage");
        DisplayUI();
    }
}
