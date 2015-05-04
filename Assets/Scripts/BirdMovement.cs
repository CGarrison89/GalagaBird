using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 Gravity;
	public Vector3 UpwardsForce;
	Vector3 velocityForce = Vector3.zero;
	Vector3 progressionForce = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {

	}

	void Update() {
		//Left button is clicked
		if (Input.GetMouseButtonDown (0)) {
			if (GameState.Dead == true && Time.timeScale == 0) {
				Time.timeScale = 1;
			}

			velocityForce += UpwardsForce * Time.deltaTime;

			if (velocityForce.y > 3) {
				velocityForce.y = 3;
			}

			transform.position += velocityForce * Time.deltaTime;
		}
	}

	void FixedUpdate () {
		//Handle gravity positioning
		velocityForce += Gravity * Time.deltaTime;
		transform.position += velocityForce * Time.deltaTime;
		transform.position += progressionForce * Time.deltaTime;
	}
}
