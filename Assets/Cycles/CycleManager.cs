using UnityEngine;

public class CycleManager : MonoBehaviour
{
    public static CycleManager instance { get; private set; }
    [SerializeField] private BedInteraction myBed;
    public int CyclePhase { get; private set; }
    private void Awake()
    {
        instance = this;
    }

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

    public void ProgressToNextCycle()   {



        CyclePhase++;
        Debug.Log(CyclePhase);
    }

}
