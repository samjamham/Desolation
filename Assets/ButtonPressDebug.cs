using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonPressDebug : MonoBehaviour
{
    [SerializeField] private UnityEvent m_UnityEvent;
    [SerializeField] private InputAction m_input;

    private void Start()
    {
        m_input.Enable();
    }
    private void Update()
    {
        if (m_input.triggered)
        {
            m_UnityEvent.Invoke();
        }
    }
}
