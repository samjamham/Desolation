using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AStarMoveDebug : MonoBehaviour
{
    [SerializeField] private AStarNavigator nav;
    [SerializeField] private AStarNode TestStart;
    [SerializeField] private AStarNode TestEnd;
    [SerializeField] private InputAction Move;
    [SerializeField] private InputAction MouseDown;
    [SerializeField] UnityEvent Event;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Move.Enable();
        //MouseDown.Enable();
        nav.FindStartPath(TestStart, TestEnd);
    }

    // Update is called once per frame
    void Update()
    {
        //Testing only ---------------------vv
        if (Move.triggered)
        {
            //nav.OnMove(); //Moved to CycleManager
        }
        if (MouseDown.triggered)
        {
            //Event.Invoke(); //Moved to MapNodeInteraction
        }        
        //Testing only ---------------------^^
    }
}
