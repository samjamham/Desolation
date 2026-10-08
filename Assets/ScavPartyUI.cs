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
    [SerializeField] private Sprite[] m_Sprites;
    [SerializeField] private UnityEvent m_DisplayEvent;
    [SerializeField] private UnityEvent m_HideEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavPartyUI(int[] IDs)
    {
        m_DisplayEvent.Invoke();
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 3; i++)
        {
            CreatePartyMemberDispaly(IDs[i]);
        }
    }
    public void HideScavPartyUI()
    {
        m_HideEvent.Invoke();
    }

    private void CreatePartyMemberDispaly(int ID)
    {
        GameObject prefab = GameObject.Instantiate(m_Prefab, m_Layout.transform);
        prefab.GetComponent<UnityEngine.UI.Image>().sprite = m_Sprites[ID];
    }
}
