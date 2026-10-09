using UnityEngine;
using UnityEngine.Events;

public class CycleManager : MonoBehaviour
{
    public static CycleManager instance { get; private set; }
    [SerializeField] private int AdditionalCycs = 0;

    public int CyclePhase { get; private set; }
    public int CycleDay { get; private set; }

    [SerializeField] UnityEvent<bool> Cycleprogess;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetCycle(0,0); //DEBUG ONLY
        if (Cycleprogess == null)
            Cycleprogess = new UnityEvent<bool>();
        foreach (AStarNavigator Navis in GameObject.FindObjectsByType(typeof(AStarNavigator)))
        {
            Cycleprogess.AddListener(Navis.OnMove);
        }
    }
    private void Update()
    {

    }
    public void SetCycle(int Phase, int Day)
    {
        CyclePhase = Phase;
        CycleDay = Day;
        Debug.Log($"Cycle:{CyclePhase}, Day:{CycleDay}");
    }

    public void ProgressToNextCycle()   {
        bool IsNight = false;
        CyclePhase++;
        if (CyclePhase > 1 + AdditionalCycs)
        {
            CycleDay++;
            CyclePhase = 0;
            IsNight = true;
        }
        Debug.Log($"Cycle:{CyclePhase}, Day:{ CycleDay}");
        Cycleprogess.Invoke(IsNight);
    }

}
