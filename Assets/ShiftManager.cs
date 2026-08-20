using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementControls myPlayer;
    public int CurrentShift { get; private set; }

    private void Start()
    {
        myPlayer.MoveToNextShift += () =>
        {
            ProgressShift();
        };
    }
    private void Update()
    {

    }

    public void ProgressShift()
    {



        CurrentShift++;
        Debug.Log(CurrentShift);
    }

}
