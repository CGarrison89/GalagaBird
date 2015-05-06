using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Init : MonoBehaviour 
{
    public Text BirdDescription;
	void Awake () 
    {
        GameState.State = GameStates.MainMenu;
        Time.timeScale = 1;

        BirdDescription.text = "";
	}
}
