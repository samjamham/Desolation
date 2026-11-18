using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingInteraction : FirstPersonInteraction_UI
{
    [Header("")]
    [SerializeField] private Craftable[] m_Craftables;
    public override void Interact()
    {
        Debug.Log("Hi I'm a Crafting");
        CraftingUI temp = m_UserInterface as CraftingUI;
        temp.SetCraftables(m_Craftables);
        DisplayUI();
    }
}
