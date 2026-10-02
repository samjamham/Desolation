using UnityEngine;
using UnityEngine.InputSystem;

public class ScryMapInteract : MonoBehaviour
{
    MapInteractionControls myInteractControls;
    private void Start()
    {
        
    }

    public bool OnClick(InputValue value)
    {
        return false;// myInteractControls.OnInteract();
    }
}
