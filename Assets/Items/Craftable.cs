using System;
using UnityEditor.UIElements;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Craftable", menuName = "Scriptable Objects/Craftable")]
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

