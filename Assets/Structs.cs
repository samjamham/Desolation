using System;
using UnityEngine;

public class Structs
{
    [Serializable]
    public struct ScavParty
    {
        public Dweller[] dwellers;
        public int remainingFood;
        public int remainingWater;
    }

    [Serializable]
    public struct ItemStack
    {
        public Item item;
        public int stackSize;
    }

    [Serializable]
    public struct DwellerStats
    {
        [Range(0, 100)] public float m_Stat_DangerCounter;
        public int m_Stat2;
        public int m_Stat3;
        public int m_Stat4;
        public int m_Stat5;
        public int m_Stat6;

        public static DwellerStats operator +(DwellerStats A, DwellerStats B)
        {
            DwellerStats C = new DwellerStats();
            C.m_Stat_DangerCounter = A.m_Stat_DangerCounter + B.m_Stat_DangerCounter;
            C.m_Stat2 = A.m_Stat2 + B.m_Stat2;
            C.m_Stat3 = A.m_Stat3 + B.m_Stat3;
            C.m_Stat4 = A.m_Stat4 + B.m_Stat4;
            C.m_Stat5 = A.m_Stat5 + B.m_Stat5;
            C.m_Stat6 = A.m_Stat6 + B.m_Stat6;

            return C;
        }
    }
}
