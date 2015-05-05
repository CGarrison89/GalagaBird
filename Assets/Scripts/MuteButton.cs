using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<AudioSource>().mute = true;
		}
	}
}
