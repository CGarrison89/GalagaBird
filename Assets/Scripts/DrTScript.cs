using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrTScript : MonoBehaviour 
{
    public float speed;

    public Sprite IdleSprite;
    public Sprite AttackSprite;
    public GameObject FireballPrefab;

    private bool wasVisible;
    private float clipLength;
    private float timeOffset;

    public Queue<GameObject> Cache;

    public void Start()
    {
        clipLength = GetComponent<AudioSource>().clip.length;
        timeOffset = Time.time;
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time - timeOffset), transform.position.z);
        bool visible = transform.position.x < 4 && transform.position.x > -6;
        if (visible && !wasVisible)
        {
            wasVisible = true;
            Invoke("TryFire", Random.Range(0, .5f));
			int enemiesSeen = PlayerPrefs.GetInt("drtcount", 0);
			++enemiesSeen;
			PlayerPrefs.SetInt("drtcount", enemiesSeen);
        }
        else if (!visible && wasVisible)
        {
            CancelInvoke("TryFire");
			wasVisible = false;
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