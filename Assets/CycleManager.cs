using UnityEngine;

public class CycleManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementControls myPlayer;
    public int CyclePhase { get; private set; }

    private void Start()
    {
        myPlayer.MoveToNextCycle += () =>
        {
            ProgressToNextCycle();
        };
    }
    private void Update()
    {

    }

    public void ProgressToNextCycle()
    {



        CyclePhase++;
        Debug.Log(CyclePhase);
    }

}
