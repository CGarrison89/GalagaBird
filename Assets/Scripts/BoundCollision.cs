using UnityEngine;
using System.Collections;

public class BoundCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			Debug.Log ("Dead");
			GameState.Dead = true;
			Time.timeScale = 0;
			Application.LoadLevel("scene_0");
		}
	}
}