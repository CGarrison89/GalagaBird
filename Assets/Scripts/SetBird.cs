using UnityEngine;
using System.Collections;

public class SetBird : MonoBehaviour 
{
    public GameObject defaultBird;
	// Use this for initialization
	void Awake() 
    {
        if (GameState.Bird != null)
            Instantiate(GameState.Bird, Vector3.zero, Quaternion.identity);
        else
            Instantiate(defaultBird, Vector3.zero, Quaternion.identity);
	}
}
