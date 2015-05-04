using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			Debug.Log ("Dead");
			Time.timeScale = 0;
		}
	}
}
