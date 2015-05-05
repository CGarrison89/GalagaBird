using UnityEngine;
using System.Collections;

public class LoveballScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(.1f, 0, 0);
        if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DrT"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            ScoreKeeper.AddScore(2);
        }
        else if (collider.gameObject.CompareTag("Fireball"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}