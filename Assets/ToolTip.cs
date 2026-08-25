using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI bodyField;

    [SerializeField] private LayoutElement LayoutElement;

    [SerializeField] private int characterWrapLimit;
    private void Start()
    {
        this.enabled = false;
    }

    public void SetText(string header, string body)
    {

        SetHeader(header);
        SetBody(body);
        int headerLength = headerField.text.Length;
        int bodyLength = bodyField.text.Length;

        LayoutElement.enabled = (headerLength > characterWrapLimit || bodyLength > characterWrapLimit) ? true : false;

        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
        }
    }
    public void SetHeader(string value)
    {
        headerField.text = value;
    }
    public void SetBody(string value)
    {
        bodyField.text = value;
    }
}
