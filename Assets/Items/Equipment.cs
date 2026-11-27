using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Items/Equipment")]
public class Equipment : Craftable
{
    public Structs.DwellerStats m_ModifiedStats;
}
