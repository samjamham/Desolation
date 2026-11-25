using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager s_Instance { get; private set; }
    public enum Playmode
    {
        FirstPerson,
        TopDown
    }

    public static Playmode playmode { get; private set; }

    private void Awake()
    {
        s_Instance = this;
    }

    public static void ChangePlayMode(Playmode value)
    {
        playmode = value;
    }
}
