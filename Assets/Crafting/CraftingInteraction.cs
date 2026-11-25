using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class CraftingInteraction : FirstPersonInteraction_UI
{
    [Header("")]
    [SerializeField] private List<Craftable> m_Craftables;
    public override void Interact()
    {
        Debug.Log("Hi I'm a Crafting");
        CraftingUI temp = m_UserInterface as CraftingUI;
        temp.SetCraftables(m_Craftables.ToList());
        DisplayUI();
    }
}
