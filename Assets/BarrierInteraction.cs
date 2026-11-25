using System.Collections.Generic;
using UnityEngine;

public class BarrierInteraction : FirstPersonInteraction
{
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] BoxCollider m_Collider;

    [Header("")]
    [SerializeField] StorageManager m_StorageManager;
    [SerializeField] List<Craftable.kvp> m_ReqItems;
    [SerializeField] BarrierWorldUI m_BarrierUI;
    public override void Interact()
    {
        foreach (Craftable.kvp item in m_ReqItems)
        {
            if (!m_StorageManager.HasItem(new KeyValuePair<Item, int>(item.Key, item.Value)))
            {
                Debug.Log("Not Enough Items"); 
                return;
            }
        }

        ////////////////////////////
        List<KeyValuePair<Item, int>> tempkvp = new List<KeyValuePair<Item, int>>();
        foreach (Craftable.kvp kvp in m_ReqItems)
        {
            KeyValuePair<Item, int> KVP = new KeyValuePair<Item, int>(kvp.Key, kvp.Value);
            tempkvp.Add(KVP);
        }
        m_StorageManager.RemoveItems(tempkvp);
        //////////////////////////////////////

        Debug.Log("Hello");
        m_Renderer.gameObject.SetActive(false);
        m_Collider.gameObject.SetActive(false);
        SetInteract(false);
    }

    public override void OnCandidateInteractable(bool value)
    {
        if (value)
        {
            m_BarrierUI.ShowUI(m_ReqItems);
        }
        else
        {
            m_BarrierUI.HideUI();
        }
        
    }
}
