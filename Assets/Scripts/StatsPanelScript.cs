using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

    public class StatsPanelScript : MonoBehaviour
    {
        private Text Text;
        public void Awake()
        {
            GameState.State = GameStates.MainMenu;
            Text = GetComponent<Text>();

            Text.text = String.Format(
                "High Score: {0}\n" +
                "{5} Deaths\n\n" +
                "Flappy Bird has bypassed:\n" +
                "{1} Double Pipes\n" +
                "{2} Ceiling Pipes\n" +
                "{3} Floor Pipes\n" +
                "{4} Enemies\n\n" +
                "Flappy Bird has seen:\n" +
                "{6} Hills\n" +
                "{7} Big Hills\n" +
                "{8} Mountains\n" +
                "{9} Bushes\n" +
                "{10} Clouds\n",
                PlayerPrefs.GetInt("highscore"),
                PlayerPrefs.GetInt("doublepipecount"),
                PlayerPrefs.GetInt("toppipecount"),
                PlayerPrefs.GetInt("bottompipecount"),
                PlayerPrefs.GetInt("drtcount"),
				PlayerPrefs.GetInt("deaths"),
                PlayerPrefs.GetInt("hillcount"),
                PlayerPrefs.GetInt("bighillcount"),
                PlayerPrefs.GetInt("mountaincount"),
                PlayerPrefs.GetInt("bushcount"),
                PlayerPrefs.GetInt("cloudcount")
                );
        }
    }