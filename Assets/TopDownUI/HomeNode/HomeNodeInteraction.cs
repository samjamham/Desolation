using UnityEngine;

public class HomeNodeInteraction : MapNodeInteraction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NodeSetup();
        m_LocationUI = GameObject.FindGameObjectWithTag("HomeNodeUI").GetComponent<HomeNodeUI>();
    }
}
