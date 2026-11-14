using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingInteraction : FirstPersonInteraction_UI
{
    public override void Interact()
    {
        Debug.Log("Hi I'm a Crafting");
        DisplayUI();
    }
}
