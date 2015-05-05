using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.Quit();
		}
	}
}
