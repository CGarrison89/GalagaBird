using UnityEngine;
using System.Collections;

public class DrTScript : MonoBehaviour 
{
    public Sprite IdleSprite;
    public Sprite AttackSprite;
    public GameObject FireballPrefab;

    private bool shouldFire;

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time), transform.position.z);
        if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            if (!shouldFire)
            {
                Debug.Log("DrT started firing");
                shouldFire = true;
                InvokeRepeating("TryFire", 0, .25f);
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
        if (Random.Range(0, 100) > 75)
        {
            GetComponent<SpriteRenderer>().sprite = AttackSprite;
            Instantiate(FireballPrefab, transform.position, Quaternion.identity);
            Invoke("DoneFiring", 0.1f);
			GetComponent<AudioSource>().Play();
        }
    }

    public void DoneFiring()
    {
        GetComponent<SpriteRenderer>().sprite = IdleSprite;
    }
}