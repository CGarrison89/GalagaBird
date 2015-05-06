using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundSpawner : MonoBehaviour 
{
    public GameObject Hill1;
    public float Hill1_Frequency_Min;
    public float Hill1_Frequency_Max;
    public int Hill1_Depth_Min;
    public int Hill1_Depth_Max;
    public float Hill1_Height_Min;
    public float Hill1_Height_Max;

    public GameObject Hill2;
    public float Hill2_Frequency_Min;
    public float Hill2_Frequency_Max;
    public int Hill2_Depth_Min;
    public int Hill2_Depth_Max;
    public float Hill2_Height_Min;
    public float Hill2_Height_Max;

    public GameObject Hill3;
    public float Hill3_Frequency_Min;
    public float Hill3_Frequency_Max;
    public int Hill3_Depth_Min;
    public int Hill3_Depth_Max;
    public float Hill3_Height_Min;
    public float Hill3_Height_Max;

    public GameObject Bush;
    public float Bush_Frequency_Min;
    public float Bush_Frequency_Max;
    public int Bush_Depth_Min;
    public int Bush_Depth_Max;
    public float Bush_Height;

    public GameObject Cloud;
    public float Cloud_Frequency_Min;
    public float Cloud_Frequency_Max;
    public int Cloud_Depth_Min;
    public int Cloud_Depth_Max;
    public float Cloud_Height_Min;
    public float Cloud_Height_Max;

    private System.Random rand = new System.Random();

    public Queue<GameObject> Hill1_Cache = new Queue<GameObject>();
    public Queue<GameObject> Hill2_Cache = new Queue<GameObject>();
    public Queue<GameObject> Hill3_Cache = new Queue<GameObject>();
    public Queue<GameObject> Bush_Cache = new Queue<GameObject>();
    public Queue<GameObject> Cloud_Cache = new Queue<GameObject>();

    void Awake()
    {
        float curX = -6;

        if (Hill1 != null)
        {
            do
            {
                curX += (float)rand.NextTriangular(Hill1_Frequency_Min, Hill1_Frequency_Max, Hill1_Frequency_Min + Hill1_Frequency_Max / 2);
                Spawn(Hill1, Hill1_Cache, curX, Hill1_Height_Min, Hill1_Height_Max, Hill1_Depth_Min, Hill1_Depth_Max);
            }
            while (curX < 9 - Hill1_Frequency_Min);
            curX = -6;
        }

        if (Hill2 != null)
        {
            do
            {
                curX += (float)rand.NextTriangular(Hill2_Frequency_Min, Hill2_Frequency_Max, Hill2_Frequency_Min + Hill2_Frequency_Max / 2);
                Spawn(Hill2, Hill2_Cache, curX, Hill2_Height_Min, Hill2_Height_Max, Hill2_Depth_Min, Hill2_Depth_Max);
            }
            while (curX < 9 - Hill2_Frequency_Min);
            curX = -6;
        }

        if (Hill3 != null)
        {
            do
            {
                curX += (float)rand.NextTriangular(Hill3_Frequency_Min, Hill3_Frequency_Max, Hill3_Frequency_Min + Hill3_Frequency_Max / 2);
                Spawn(Hill3, Hill3_Cache, curX, Hill3_Height_Min, Hill3_Height_Max, Hill3_Depth_Min, Hill3_Depth_Max);
            }
            while (curX < 9 - Hill3_Frequency_Min);
            curX = -6;
        }

        if (Bush != null)
        {
            do
            {
                curX += (float)rand.NextTriangular(Bush_Frequency_Min, Bush_Frequency_Max, Bush_Frequency_Min + Bush_Frequency_Max / 2);
                Spawn(Bush, Bush_Cache, curX, Bush_Height, Bush_Depth_Min, Bush_Depth_Max);
            }
            while (curX < 9 - Bush_Frequency_Min);
            curX = -6;
        }

        if (Cloud != null)
        {
            do
            {
                curX += (float)rand.NextTriangular(Cloud_Frequency_Min, Cloud_Frequency_Max, Cloud_Frequency_Min + Cloud_Frequency_Max / 2);
                Spawn(Cloud, Cloud_Cache, curX, Cloud_Height_Min, Cloud_Height_Max, Cloud_Depth_Min, Cloud_Depth_Max);
            }
            while (curX < 9 - Cloud_Frequency_Min);
            curX = -6;
        }
    }

	void Start()
    {
        Invoke("SpawnHill1", Random.Range(Hill1_Frequency_Min, Hill1_Frequency_Max));
        Invoke("SpawnHill2", Random.Range(Hill2_Frequency_Min, Hill2_Frequency_Max));
        Invoke("SpawnHill3", Random.Range(Hill3_Frequency_Min, Hill3_Frequency_Max));
        Invoke("SpawnBush", Random.Range(Bush_Frequency_Min, Bush_Frequency_Max));
        Invoke("SpawnCloud", Random.Range(Cloud_Frequency_Min, Cloud_Frequency_Max));
	}

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float xPos, float Height_Min, float Height_Max, int Depth_Min, int Depth_Max)
    {
        float height = (float)rand.NextTriangular(Height_Min, Height_Max, (Height_Min + Height_Max) * .5);
        int depth = (int)rand.NextTriangular(Depth_Min, Depth_Max, (Depth_Min + Depth_Max) * .5);
        Spawn(prefab, Cache, xPos, height, depth);
    }

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float xPos, float Height, int Depth_Min, int Depth_Max)
    {
        int depth = (int)rand.NextTriangular(Depth_Min, Depth_Max, (Depth_Min + Depth_Max) * .5);
        Spawn(prefab, Cache, xPos, Height, depth);
    }

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float xPos, float Height, int Depth)
    {
        Vector3 position = new Vector3(xPos, Height, 0);
        GameObject spawn;

        if (Cache.Count <= 0)
        {
            spawn = Instantiate(prefab, position, Quaternion.identity) as GameObject;
            spawn.GetComponent<DoodadMovement>().Cache = Cache;
            spawn.transform.parent = transform;
            Debug.Log("Created new " + prefab.name);
        }
        else
        {
            spawn = Cache.Dequeue();
            Debug.Log("Dequeued " + prefab.name);
        }

        spawn.transform.position = position;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Depth;
    }

    void SpawnHill1()
    {
        if (Hill1 != null)
        {
            Spawn(Hill1, Hill1_Cache, 9, Hill1_Height_Min, Hill1_Height_Max, Hill1_Depth_Min, Hill1_Depth_Max);
            Invoke("SpawnHill1", Random.Range(Hill1_Frequency_Min, Hill1_Frequency_Max));
        }
    }
    void SpawnHill2()
    {
        if (Hill2 != null)
        {
            Spawn(Hill2, Hill2_Cache, 9, Hill2_Height_Min, Hill2_Height_Max, Hill2_Depth_Min, Hill2_Depth_Max);
            Invoke("SpawnHill2", Random.Range(Hill2_Frequency_Min, Hill2_Frequency_Max));
        }
    }
    void SpawnHill3()
    {
        if (Hill3 != null)
        {
            Spawn(Hill3, Hill3_Cache, 9, Hill3_Height_Min, Hill3_Height_Max, Hill3_Depth_Min, Hill3_Depth_Max);
            Invoke("SpawnHill3", Random.Range(Hill3_Frequency_Min, Hill3_Frequency_Max));
        }
    }
    void SpawnBush()
    {
        if (Bush != null)
        {
            Spawn(Bush, Bush_Cache, 9, Bush_Height, Bush_Depth_Min, Bush_Depth_Max);
            Invoke("SpawnBush", Random.Range(Bush_Frequency_Min, Bush_Frequency_Max));
        }
    }
    void SpawnCloud()
    {
        if (Cloud != null)
        {
            Spawn(Cloud, Cloud_Cache, 9, Cloud_Height_Min, Cloud_Height_Max, Cloud_Depth_Min, Cloud_Depth_Max);
            Invoke("SpawnCloud", Random.Range(Cloud_Frequency_Min, Cloud_Frequency_Max));
        }
    }
}
