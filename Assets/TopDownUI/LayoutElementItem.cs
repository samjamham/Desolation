using UnityEngine;
using UnityEngine.UI;

public class LayoutElementItem : MonoBehaviour
{
    [SerializeField] private GameObject m_Image;
    public void ChangeIcon(Sprite image)
    {
        m_Image.GetComponent<Image>().sprite = image;
    }
}
