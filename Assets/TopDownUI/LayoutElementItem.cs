using TMPro;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class LayoutElementItem : MonoBehaviour
{
    [SerializeField] private Image m_Image;
    [SerializeField] private TextMeshProUGUI m_Text;
    [SerializeField] private Item m_Item;
    public void ChangeIcon(Sprite image)
    {
        m_Image.sprite = image;
    }
    public void SetColour(Color color)
    {
        GetComponent<Image>().color = color;
    }
    public void SetStackSize(int value)
    {
        if (m_Text is null)
            return;
        m_Text.gameObject.SetActive(false);
        if (value == 1)
            return;
        m_Text.gameObject.SetActive(true);
        m_Text.text = value.ToString();
    }

    public void SetItem (Item item)
    {
        m_Item = item;
        ChangeIcon(item.m_Sprite);
    }
}
