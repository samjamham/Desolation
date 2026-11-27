using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Items/Craftable")]
public class Craftable : Item
{
    [Serializable]
    public struct kvp
    {
        public Item Key;
        public int Value;
    }

    public List<kvp> ReqIngredient;
}

