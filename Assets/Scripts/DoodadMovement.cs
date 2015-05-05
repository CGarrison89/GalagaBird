using UnityEngine;
using System.Collections;

public class DoodadMovement : MonoBehaviour 
{

    public float speed;
    public StatType Type;
    public int Value;

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
            Destroy(gameObject);
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
