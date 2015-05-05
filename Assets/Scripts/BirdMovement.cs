using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 Gravity;
	public Vector3 UpwardsForce;
	Vector3 velocityForce = Vector3.zero;

    public GameObject Loveball;

    private KeyCode wasPressed = KeyCode.None;

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

        if (Input.GetKeyDown(KeyCode.Space) && wasPressed == KeyCode.None)
            wasPressed = KeyCode.Space;
        else if (Input.GetKeyUp(KeyCode.Space) && wasPressed == KeyCode.Space)
        {
            Instantiate(Loveball, transform.position, Quaternion.identity);
            wasPressed = KeyCode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && wasPressed == KeyCode.None)
            wasPressed = KeyCode.Escape;
        else if (Input.GetKeyUp(KeyCode.Escape) && wasPressed == KeyCode.Escape)
        {
            wasPressed = KeyCode.None;
            Time.timeScale = 1;
            GameState.Dead = true;
            Application.LoadLevel("MainMenu");
        }

	}

	void FixedUpdate () {
		//Handle gravity positioning
		velocityForce += Gravity * Time.deltaTime;
		transform.position += velocityForce * Time.deltaTime;
	}


}
