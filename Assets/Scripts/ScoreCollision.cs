using UnityEngine;
using System.Collections;

public class ScoreCollision : MonoBehaviour 
{
    private bool hasScored = false;
    private bool wasVisible = false;

    public StatType Type;
    public int Value;

	void Update()
    {
        bool isVisible = transform.position.x < 4 && transform.position.x > -4;
        if (isVisible && transform.position.x < 0 && !hasScored)
        {
            ScoreKeeper.AddScore(1);
            hasScored = true;

            int newVal = PlayerPrefs.GetInt(Type.ToString(), 0) + Value;
            PlayerPrefs.SetInt(Type.ToString(), newVal);
        }


        if (!isVisible && wasVisible)
            hasScored = false;

        wasVisible = isVisible;
	}
}
