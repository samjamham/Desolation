using System;
using UnityEngine;
using UnityEngine.Events;

public class CycleManager : MonoBehaviour
{
    public static CycleManager s_Instance { get; private set; }
    [SerializeField] private int m_AdditionalCycs = 0;

    public int m_CyclePhase { get; private set; }
    public int m_CycleDay { get; private set; }

    public UnityEvent<bool> m_CycleProgess;
    public UnityEvent m_DayProgess;
    public enum CycleType
    {
        CycleDay,
        CycleNight
    }
    private void Awake()
    {
        s_Instance = this;
    }

    private void Start()
    {
        SetCycle(0,0); //DEBUG ONLY
        if (m_CycleProgess == null)
            m_CycleProgess = new UnityEvent<bool>();
        if (m_DayProgess == null)
            m_DayProgess = new UnityEvent();
    }
    public void SetCycle(int Phase, int Day)
    {
        m_CyclePhase = Phase;
        m_CycleDay = Day;
        Debug.Log($"Cycle:{m_CyclePhase}, Day:{m_CycleDay}");
    }

    public void ProgressToNextCycle()   {
        bool IsNight = false;
        m_CyclePhase++;
        if (m_CyclePhase > 1 + m_AdditionalCycs)
        {
            m_CycleDay++;
            m_CyclePhase = 0;
            IsNight = true;
            ProgressToNextDay();
        }
        Debug.Log($"Cycle:{m_CyclePhase}, Day:{ m_CycleDay}");
        m_CycleProgess.Invoke(IsNight);
    }
    public void ProgressToNextDay()
    {
        m_DayProgess.Invoke();
    }

}
