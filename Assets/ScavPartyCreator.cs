using UnityEngine;

public class ScavPartyCreator : MonoBehaviour
{
    [SerializeField] private ScryMapDrag ScryMap;
    public void CreateScavParty()
    {
        Structs.ScavParty SPDebug = new Structs.ScavParty();

        ScryMap.CreateScavParty(SPDebug);
    }
}
