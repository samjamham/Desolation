using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ScavPartyUI : MonoBehaviour
{   [SerializeField] private GameObject m_Layout;
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private UnityEvent m_DisplayEvent;
    [SerializeField] private UnityEvent m_HideEvent;
    private MapController m_MapController;
    [SerializeField] private Toggle m_Toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MapController = GameObject.FindGameObjectWithTag("ScryMap").GetComponent<MapController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavPartyUI(Structs.ScavParty ScavParty, bool NightTravel)
    {
        m_Toggle.SetIsOnWithoutNotify(NightTravel);
        m_DisplayEvent.Invoke();
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 3; i++)
        {
            CreatePartyMemberDispaly(ScavParty.dwellers[i]);
        }

    }
    private void CreatePartyMemberDispaly(Dweller Dweller)
    {
        GameObject prefab = GameObject.Instantiate(m_Prefab, m_Layout.transform);
        prefab.GetComponent<UnityEngine.UI.Image>().sprite = Dweller.m_Sprite;
    }
    public void DeseletScavParty()
    {
        m_MapController.SetSelection(null);
    }
    public void HideScavPartyUI()
    {
        m_HideEvent.Invoke();
    }

    public void SetNightTravel()
    {
        bool value = m_Toggle.isOn;
        m_MapController?.SetNightTravel(value);
    }    
}
