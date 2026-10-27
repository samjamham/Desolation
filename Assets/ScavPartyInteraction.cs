using UnityEngine;

public class ScavPartyInteraction : TopDownInteraction
{
    [SerializeField] ToolTipTriggerMap m_ToolTipTriggerMap;
    private ScavPartyUI m_PartyUI;
    private AStarNavigator m_Navigator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_PartyUI = GameObject.FindGameObjectWithTag("ScavPartyUI").GetComponent<ScavPartyUI>();
        m_Navigator = gameObject.GetComponent<AStarNavigator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        m_Controller.SetSelection(this);
    }
    public override void OnMouseEnter()
    {
        m_Controller.SetHovered(this);
        m_ToolTipTriggerMap.HoverTriggerEnter();

    }
    public override void OnMouseExit()
    {
        m_Controller.SetHovered(null);
        m_ToolTipTriggerMap.HoverTriggerExit();
    }

    public override void OnSelected()
    {
        ScavParty SP = GetComponent<ScavParty>();
        m_PartyUI?.DisplayScavPartyUI(SP.GetScavParty(), gameObject.GetComponent<ScavParty>().GetNightTravel(), SP.GetScavItems());
    }
    public override void OnDeselected()
    {
        m_PartyUI?.HideScavPartyUI();
        m_Navigator.ClearPotentalPath();
    }
}
