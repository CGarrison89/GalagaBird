using UnityEngine;
using System.Collections;

public class BoundsMovement : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 position = player.transform.position;
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
	}
}
