using UnityEngine;

public class DEBUGScavParty : MonoBehaviour
{
    [SerializeField] private ScavParty m_ScavParty;

    private void Start()
    {
        foreach(Dweller D in  m_ScavParty.GetScavParty().dwellers)
        {
            D.m_IsActive = true;
        }
    }
}
