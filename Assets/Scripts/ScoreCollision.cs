using UnityEngine;
using System.Collections;

public class ScoreCollision : MonoBehaviour 
{
    private GameObject Player;
    private bool hasScored = false;

    public StatType Type;
    public int Value;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update()
    {
        float distance =  transform.position.x - Player.transform.position.x;
        if (distance < 0 && !hasScored)
        {
            ScoreKeeper.AddScore(1);
            hasScored = true;

            int newVal = PlayerPrefs.GetInt(Type.ToString(), 0) + Value;
            PlayerPrefs.SetInt(Type.ToString(), newVal);
        }
	}
}
