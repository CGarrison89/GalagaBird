using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public static GameStates State = GameStates.GameWaiting;
    public static GameObject Bird;
}

public enum GameStates
{
    MainMenu,
    GameWaiting,
    Dying,
    Playing
}
