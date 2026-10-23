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
        //TODO ADD:
        //inventory 
    }
}
