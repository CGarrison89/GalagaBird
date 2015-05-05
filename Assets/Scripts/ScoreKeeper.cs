using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	static GameObject scoreText;

	public static int Score = 0;
	public static int HighScore = 0;

	void Start() {
		HighScore = PlayerPrefs.GetInt("highscore");
		scoreText = GameObject.FindGameObjectWithTag ("Score");
		Text t = scoreText.GetComponent<Text> ();
		t.text = "Score: " + Score.ToString () + "\nHigh Score: " + HighScore;
	}

	public static void AddScore(int inScore) {
		Score += inScore;
		scoreText = GameObject.FindGameObjectWithTag ("Score");
		Text t = scoreText.GetComponent<Text> ();

		if (Score > HighScore) {
			HighScore = Score;
			PlayerPrefs.SetInt ("highscore", HighScore);
		}

		t.text = "Score: " + Score.ToString () + "\nHigh Score: " + HighScore;
	}
}
