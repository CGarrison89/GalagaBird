using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 Gravity;
	public Vector3 UpwardsForce;
	Vector3 velocityForce = Vector3.zero;

	// Use this for initialization
	void Start () {

	}

	void Update() {
		//Left button is clicked
		if (Input.GetMouseButtonDown (0)) {
			velocityForce += UpwardsForce * Time.deltaTime;

			if (velocityForce.y > 4) {
				velocityForce.y = 4;
			}

			transform.position += velocityForce * Time.deltaTime;
		}
	}

	void FixedUpdate () {
		//Handle gravity positioning
		velocityForce += Gravity * Time.deltaTime;
		transform.position += velocityForce * Time.deltaTime;
	}
}
