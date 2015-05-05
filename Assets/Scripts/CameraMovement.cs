using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject Player;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Player.transform.position.x, 0f, -10f);
	}
}
