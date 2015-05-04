using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-.1f, 0, 0);
        if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            Destroy(gameObject);
    }
}