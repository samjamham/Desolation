using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem current;

    [SerializeField] private ToolTip ToolTip;

    private void Awake()
    {
        current = this;
    }

    public static void Show(string header, string body)
    {
        current.ToolTip.gameObject.SetActive(true);
        current.ToolTip.SetText(header,body);
    }
    public static void Hide()
    {
        current.ToolTip.gameObject.SetActive(false);
    }
}
