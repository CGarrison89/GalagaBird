using UnityEngine;
using System.Collections;

public class GroundMovement : MonoBehaviour 
{
    public float speed;

    private bool wasVisible = false;

	void Update () 
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        bool isVisible = GetComponent<Renderer>().IsVisibleFrom(Camera.main);

        if (isVisible && !wasVisible)
            wasVisible = true;
        else if (!isVisible && wasVisible)
        {
            transform.position = new Vector3(transform.position.x + 24, transform.position.y, transform.position.z);
            wasVisible = false;
        }
	}
}
