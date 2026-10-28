using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LayoutElementItem : MonoBehaviour
{
    [SerializeField] private GameObject m_Image;
    [SerializeField] private TextMeshProUGUI m_Text;
    public void ChangeIcon(Sprite image)
    {
        m_Image.GetComponent<Image>().sprite = image;
    }
    public void SetStackSize(int value)
    {
        m_Text.gameObject.SetActive(true);
        if (m_Text is null)
            return;
        if (value == 1)
        {
            m_Text.gameObject.SetActive(false);
            return;
        }
        m_Text.text = value.ToString();
    }
}
