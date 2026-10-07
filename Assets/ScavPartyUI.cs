using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ScavPartyUI : MonoBehaviour
{
    [SerializeField] private UnityEvent m_Event;
    [SerializeField] private GameObject m_Layout;
    [SerializeField] private GameObject m_Prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScavParty(int placeholder1)
    {
        m_Event.Invoke();
        for (int i = m_Layout.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(m_Layout.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i <= 3; i++ )
        {
            CreatePartyMemberDispaly(i);
        }
    }

    private void CreatePartyMemberDispaly(int placeholder1)
    {
        GameObject prefab =  GameObject.Instantiate(m_Prefab,m_Layout.transform);
    }
}
