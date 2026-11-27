using UnityEngine;

public class ScavLocationInteraction : MapNodeInteraction
{
    void Start()
    {
        NodeSetup();
        m_LocationUI = GameObject.FindGameObjectWithTag("ScavLocationUI").GetComponent<ScavLocationUI>();
    }
    public override void OnSelected()
    {
        ScavLocationUI temp = m_LocationUI as ScavLocationUI;
        temp?.DisplayScavLocationUI(gameObject.GetComponent<ScavLocation>().GetDiscoverableItems());
    }
}
