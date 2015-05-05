using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoodadMovement : MonoBehaviour 
{

    public float speed;
    public StatType Type;
    public int Value;
    public Queue<GameObject> Cache;

    private bool wasVisible = false;

	void Update() 
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        bool isVisible = GetComponent<Renderer>().IsVisibleFrom(Camera.main);

        if (isVisible && !wasVisible)
        {
            wasVisible = true;
            int newVal = PlayerPrefs.GetInt(Type.ToString(), 0) + Value;
            PlayerPrefs.SetInt(Type.ToString(), newVal);
        }
        else if (!isVisible && wasVisible)
        {
            if (Cache == null)
                Destroy(gameObject);
            else
            {
                Cache.Enqueue(gameObject);
                wasVisible = false;
            }
        }
	}
}

public enum StatType
{
    doublepipecount,
    toppipecount,
    bottompipecount,
    drtcount,
    hillcount,
    bighillcount,
    mountaincount,
    bushcount,
    cloudcount
}
