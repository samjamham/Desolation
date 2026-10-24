using UnityEngine;
using UnityEngine.Events;

public class TopDownUI : MonoBehaviour
{
    [SerializeField] protected UnityEvent m_DisplayEvent;
    [SerializeField] protected UnityEvent m_HideEvent;
    protected MapController m_MapController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_MapController = GameObject.FindGameObjectWithTag("ScryMap").GetComponent<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DisplayUI() 
    {
        m_DisplayEvent.Invoke();
    }
    public virtual void HideUI() 
    {
        m_HideEvent.Invoke();
    }
    public virtual void DeseletInteractable()
    {
        m_MapController.SetSelection(null);
    }
}
