using UnityEngine;

[CreateAssetMenu(fileName = "Dweller", menuName = "Scriptable Objects/Dweller")]
public class Dweller : ScriptableObject
{
    public Sprite m_Sprite;
    public Mesh m_Mesh;
    public int m_ID;
    public Structs.DwellerStats m_BaseStats;
    public Equipment m_Equipment;
    public bool m_IsInjured;
    public bool m_IsActive;

    public Structs.DwellerStats GetModifiedStats()
    {
        if (m_Equipment is not null)
            return m_BaseStats + m_Equipment.m_ModifiedStats;

        return m_BaseStats;
    }
}