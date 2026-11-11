using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderToTMP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TMP;
    [SerializeField] Slider m_Slider;

    public void SetText()
    {
        m_TMP.text = m_Slider.value.ToString();
    }
}
