using UnityEngine;

public class Structs
{
    public struct Dweller
    {
        public string Name;
        //TODO ADD:
        //Model / sprite
        //stats?
        //Special abilities s
    }
    public struct ScavParty
    {
        public Dweller[] partyMembers;
        public int remainingFood;
        public int remainingWater;
        //TODO ADD:
        //inventory 
    }
}
