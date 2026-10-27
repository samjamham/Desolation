using UnityEngine;

public class HomeNodeInteraction : MapNodeInteraction
{
    public override void OnSelected()
    {
        m_LocationUI?.DisplayScavLocationUI(gameObject.GetComponent<ScavLocation>().GetFoundItems());
        Debug.Log("I'm Unique");
    }
    public override void OnDeselected()
    {
        m_LocationUI?.HideScavLocationUI();
    }
}
