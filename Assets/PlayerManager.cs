using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }
    public enum Playmode
    {
        FirstPerson,
        TopDown
    }

    public static Playmode playmode { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public static void ChangePlayMode(Playmode value)
    {
        playmode = value;
    }
}
