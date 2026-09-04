using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem current;

    [SerializeField] private ToolTip ToolTip;
    private static Camera cam;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
        
    public static void Show(string header, string body)
    {
        current.ToolTip.SetText(header, body);
        current.ToolTip.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        current.ToolTip.gameObject.SetActive(false);
    }
}
