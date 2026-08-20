using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField]
    private InteractionBox interactionBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InteractionIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMapInteract(InputValue value)
    {
        interactionBox.MapInteract();
    }
}
