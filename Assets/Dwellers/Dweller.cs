using UnityEngine;

[CreateAssetMenu(fileName = "Dweller", menuName = "Scriptable Objects/Dweller")]
public class Dweller : ScriptableObject
{
    public Sprite m_Sprite;
    public Mesh m_Mesh;
    public int m_Stat1;
    public int m_Stat2;
    public int m_Stat3;
    public int m_Stat4;
    public int m_Stat5;
    public int m_Stat6;
    public bool m_IsInjured;
    public bool m_IsActive;
}