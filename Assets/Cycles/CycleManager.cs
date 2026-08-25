using UnityEngine;

public class CycleManager : MonoBehaviour
{
    [SerializeField]
    private BedInteraction myBed;
    public int CyclePhase { get; private set; }

    private void Start()
    {
        myBed.MoveToNextCycle += () =>
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
