using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI bodyField;
    [SerializeField] private LayoutElement LayoutElement;
    [SerializeField] private InputAction MousePos;
    [SerializeField] private InputAction MouseClick;
    private Vector2 MousePosition;
    private Vector2 PivotPoint;
    private RectTransform RectTransform;

    [SerializeField] private int characterWrapLimit;
    private void Start()
    {
        gameObject.SetActive(false);
        MousePos.Enable();
        MouseClick.Enable();
        RectTransform = (RectTransform)transform;
    }
    void OnMouseClick()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        UpdatePosition();
        MouseClick.performed += context =>
        {
            OnMouseClick();
        };
    }
    void UpdatePosition()
    {
        MousePosition = MousePos.ReadValue<Vector2>();
        transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
    }
    void UpdatePivot()
    {
        PivotPoint = MousePosition.x > (Screen.width / 2) ? MousePosition.y > (Screen.height / 2) ? new Vector2(1, 1) : new Vector2(1, 0) : MousePosition.y > (Screen.height / 2) ? new Vector2(0, 1) : new Vector2(0, 0);       
        if (RectTransform is not null)
        {
            RectTransform.pivot = PivotPoint;
        }
    }
    public void SetText(string header, string body)   {

        SetHeader(header);
        SetBody(body);
        UpdatePosition();
        UpdatePivot();
        int headerLength = headerField.text.Length;
        int bodyLength = bodyField.text.Length;

        LayoutElement.enabled = (headerLength > characterWrapLimit || bodyLength > characterWrapLimit) ? true : false;
        Emptycheck(header, headerField);
        Emptycheck(body, bodyField);


    }
    public void SetHeader(string value)
    {
        headerField.text = value;
    }
    public void SetBody(string value)
    {
        bodyField.text = value;
    }
    private void Emptycheck(string value, TextMeshProUGUI obj)
    {
        if (string.IsNullOrEmpty(value))
        {
            obj.gameObject.SetActive(false);
        }
        else
        {
            obj.gameObject.SetActive(true);
        }
    }
}
