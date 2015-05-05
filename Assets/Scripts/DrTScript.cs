using UnityEngine;
using System.Collections;

public class DrTScript : MonoBehaviour 
{
    public float speed;

    public Sprite IdleSprite;
    public Sprite AttackSprite;
    public GameObject FireballPrefab;

    private bool shouldFire;
    private float clipLength;

    private System.Random rand = new System.Random();

    public void Start()
    {
        clipLength = GetComponent<AudioSource>().clip.length;
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, Mathf.Sin(Time.time), transform.position.z);
        if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            if (!shouldFire)
            {
                Debug.Log("DrT started firing");
                shouldFire = true;
                Invoke("TryFire", Random.Range(0, .5f));
            }
        }
        else if (shouldFire)
        {
            Debug.Log("DrT stopped firing");
            CancelInvoke("TryFire");
			shouldFire = false;
        }
    }

    public void TryFire()
    {
        GetComponent<SpriteRenderer>().sprite = AttackSprite;
        Instantiate(FireballPrefab, transform.position, Quaternion.identity);
        Invoke("DoneFiring", 0.1f);
        GetComponent<AudioSource>().Play(); ;

        Invoke("TryFire", Random.Range(clipLength, clipLength + 1));
    }

    public void DoneFiring()
    {
        GetComponent<SpriteRenderer>().sprite = IdleSprite;
    }
}