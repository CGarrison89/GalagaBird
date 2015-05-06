using UnityEngine;
using System.Collections;

public class BoundCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) 
        {
            if (GameState.State != GameStates.Dying)
            {
                var bird = collider.gameObject;
                bird.SendMessage("Die");
            }
		}
	}
}