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
}
