using System;
using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Items/Item")]
public class Item : ScriptableObject, IComparable<Item>
{
    [SerializeField] private int ID;
    public Sprite m_Sprite;
    public float m_Weight;

    public int CompareTo(Item other)
    {
        if (other == null)
            return 1;

        return ID.CompareTo(other.ID);
    }
}

