using System.Linq;
using UnityEngine;

public class DEBUGScavParty : MonoBehaviour
{
    [SerializeField] private ScavParty m_ScavPartyComponent;
    [SerializeField] private Structs.ScavParty m_ScavParty;
    [SerializeField] private DwellerManager m_DwellerManger;

    private void Awake()
    {
        m_DwellerManger = GameObject.FindGameObjectWithTag("DwellerManager").GetComponent<DwellerManager>();
        int i = 0;
        Dweller[] dwellers = new Dweller[4];
        foreach(Dweller D in m_ScavParty.dwellers)
        {
            dwellers[i] = m_DwellerManger.m_DwellerList.Find(x => x.ID == D.ID);
            dwellers[i].m_IsActive = true;
            i++;
        }
        Structs.ScavParty Party = new Structs.ScavParty();
        Party.dwellers = dwellers;
        Party.remainingFood = 69;
        Party.remainingWater = 69;
        m_ScavPartyComponent.SetScavParty(Party);
    }
}
