using UnityEngine;

public class BarrierInteraction : FirstPersonInteraction
{
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] BoxCollider m_Collider;
    public override void Interact()
    {
        Debug.Log("Hello");
        m_Renderer.gameObject.SetActive(false);
        m_Collider.gameObject.SetActive(false);
        SetInteract(false);
    }
}
