using UnityEngine;
using System.Collections;

public class ScoreCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			Debug.Log ("Score increase");
			ScoreKeeper.AddScore(1);
		}
	}
}
