using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 Gravity;
	public Vector3 UpwardsForce;
	Vector3 velocityForce = Vector3.zero;
	Vector3 progressionForce = new Vector3(1, 0, 0);

    public GameObject Loveball;

    private bool wasPressed = false;

	// Use this for initialization
	void Start () {

	}

	void Update() {
		//Left button is clicked
		if (Input.GetMouseButtonDown (0)) {
			if (GameState.Dead == true && Time.timeScale == 0) {
				GameState.Dead = false;
				Time.timeScale = 1;
			}

			velocityForce += UpwardsForce * Time.deltaTime;

			if (velocityForce.y > 3) {
				velocityForce.y = 3;
			}

			transform.position += velocityForce * Time.deltaTime;
		}

        if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
            wasPressed = true;
        else if (Input.GetKeyUp(KeyCode.Space) && wasPressed)
        {
            Instantiate(Loveball, transform.position, Quaternion.identity);
            wasPressed = false;
        }

	}

	void FixedUpdate () {
		//Handle gravity positioning
		velocityForce += Gravity * Time.deltaTime;
		transform.position += velocityForce * Time.deltaTime;
		transform.position += progressionForce * Time.deltaTime;
	}


}
