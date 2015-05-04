using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag ("Background")) {
			Vector3 currentPosition = collider.gameObject.transform.position;
			currentPosition += new Vector3(15.98f, 0, 0);
			collider.gameObject.transform.position = currentPosition;
			Debug.Log ("Reset");
		}
	}
}
