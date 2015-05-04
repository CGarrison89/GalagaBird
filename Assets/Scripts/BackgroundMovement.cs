using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag ("Background")) {
			Vector3 currentPosition = collider.gameObject.transform.position;
			currentPosition += new Vector3(15.98f, 0, 0);
			collider.gameObject.transform.position = currentPosition;
			Debug.Log ("Moved background");
		}
		if (collider.gameObject.CompareTag("Pipes")) {
			Vector3 currentPosition = collider.gameObject.transform.position;
			currentPosition = new Vector3(currentPosition.x + 7f, Random.Range(0f, 1f), -1);
			collider.gameObject.transform.position = currentPosition;
			Debug.Log ("Moved pipes");
		}
		if (collider.gameObject.CompareTag ("DrT")) {
			Vector3 currentPosition = collider.gameObject.transform.position;
			currentPosition = new Vector3(currentPosition.x + 7f, 0, -1);
			collider.gameObject.transform.position = currentPosition;
			Debug.Log ("Dr. T has been moved");
		}
	}
}
