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

	void Start()
    {
        Invoke("SpawnHill1", Random.Range(Hill1_Frequency_Min, Hill1_Frequency_Max));
        Invoke("SpawnHill2", Random.Range(Hill2_Frequency_Min, Hill2_Frequency_Max));
        Invoke("SpawnHill3", Random.Range(Hill3_Frequency_Min, Hill3_Frequency_Max));
        Invoke("SpawnBush", Random.Range(Bush_Frequency_Min, Bush_Frequency_Max));
        Invoke("SpawnCloud", Random.Range(Cloud_Frequency_Min, Cloud_Frequency_Max));
	}

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float Height_Min, float Height_Max, int Depth_Min, int Depth_Max)
    {
        Spawn(prefab, Cache, (float)rand.NextTriangular(Height_Min, Height_Max, (Height_Min + Height_Max) * .5), Depth_Min, Depth_Max);
    }

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float Height, int Depth_Min, int Depth_Max)
    {
        Spawn(prefab, Cache, Height, (int)rand.NextTriangular(Depth_Min, Depth_Max, (Depth_Min + Depth_Max) * .5));
    }

    void Spawn(GameObject prefab, Queue<GameObject> Cache, float Height, int Depth)
    {
        Vector3 position = new Vector3(9, Height, 0);
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
            Spawn(Hill1, Hill1_Cache, Hill1_Height_Min, Hill1_Height_Max, Hill1_Depth_Min, Hill1_Depth_Max);
            Invoke("SpawnHill1", Random.Range(Hill1_Frequency_Min, Hill1_Frequency_Max));
        }
    }
    void SpawnHill2()
    {
        if (Hill2 != null)
        {
            Spawn(Hill2, Hill2_Cache, Hill2_Height_Min, Hill2_Height_Max, Hill2_Depth_Min, Hill2_Depth_Max);
            Invoke("SpawnHill2", Random.Range(Hill2_Frequency_Min, Hill2_Frequency_Max));
        }
    }
    void SpawnHill3()
    {
        if (Hill3 != null)
        {
            Spawn(Hill3, Hill3_Cache, Hill3_Height_Min, Hill3_Height_Max, Hill3_Depth_Min, Hill3_Depth_Max);
            Invoke("SpawnHill3", Random.Range(Hill3_Frequency_Min, Hill3_Frequency_Max));
        }
    }
    void SpawnBush()
    {
        if (Bush != null)
        {
            Spawn(Bush, Bush_Cache, Bush_Height, Bush_Depth_Min, Bush_Depth_Max);
            Invoke("SpawnBush", Random.Range(Bush_Frequency_Min, Bush_Frequency_Max));
        }
    }
    void SpawnCloud()
    {
        if (Cloud != null)
        {
            Spawn(Cloud, Cloud_Cache, Cloud_Height_Min, Cloud_Height_Max, Cloud_Depth_Min, Cloud_Depth_Max);
            Invoke("SpawnCloud", Random.Range(Cloud_Frequency_Min, Cloud_Frequency_Max));
        }
    }
}
