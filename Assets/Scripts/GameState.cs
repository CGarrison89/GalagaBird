using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public static GameStates State = GameStates.GameWaiting;
}

public enum GameStates
{
    MainMenu,
    GameWaiting,
    Dying,
    Playing
}
