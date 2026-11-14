using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftingUI : FirstPersonInteractableUI
{
    [SerializeField] private StorageManager m_StorageManager;
    public override void DisplayUI()
    {
        m_DisplayEvent.Invoke();
        ClearDisplay();
    }
    public void HideStorageUI()
    {
        m_HideEvent.Invoke();
    }
    private void ClearDisplay()
    {
    }
}
