using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HomeNodeUI : NodeUI
{
    [SerializeField] private GameObject m_ToggleGroup;
    [SerializeField] private Sprite m_ClearImage;
    [SerializeField] private ScavPartyCreator m_Creator;
    public override void DisplayUI()
    {
        m_DisplayEvent.Invoke();
        ClearSelections();
    }

    void ClearSelections()
    {
        foreach(Transform t in m_ToggleGroup.transform)
        {
            t.GetChild(0).GetComponent<Image>().sprite = m_ClearImage;
        }
        Toggle temp = m_ToggleGroup.GetComponent<ToggleGroup>().GetFirstActiveToggle();
        if (temp is not null)
            temp.isOn = false;
        m_Creator.ClearDwellers();
    }
}
