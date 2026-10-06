using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private TopDownInteraction m_CurrentSelection;
    [SerializeField] private TopDownInteraction m_CurrentHover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelection(TopDownInteraction Interactable)
    {
        m_CurrentSelection?.GetDeselected();
        Interactable?.GetSelected();
        m_CurrentSelection = Interactable;
    }
    public TopDownInteraction GetSelection()
    {
        return m_CurrentSelection;
    }
    public void SetHovered(TopDownInteraction Interactable)
    {
        if (m_CurrentSelection == null)
            return;
        Navi_NodeInteraction(Interactable);
    }
    public TopDownInteraction GetHovered()
    {
        return m_CurrentHover;
    }

    void Navi_NodeInteraction(TopDownInteraction Interactable)
    {
        if (Interactable == null && m_CurrentSelection is NavigatorInteraction)
        {
            m_CurrentSelection.GetComponent<AStarNavigator>().ClearPotentalPath();
        }
        else if(Interactable is MapNodeInteraction && m_CurrentSelection is NavigatorInteraction)
        {
            m_CurrentSelection.GetComponent<AStarNavigator>().FindPotenalPath(Interactable.GetComponent<MapNodeInteraction>().GetNode());
        }

    }    
}
