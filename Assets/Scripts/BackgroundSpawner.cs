using UnityEngine;
using System.Collections;

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

	void Start()
    {
        Invoke("SpawnHill1", Random.Range(0, .1f));
        Invoke("SpawnHill2", Random.Range(0, .1f));
        Invoke("SpawnHill3", Random.Range(0, .1f));
        Invoke("SpawnBush", Random.Range(0, .1f));
        Invoke("SpawnCloud", Random.Range(0, .1f));
	}

    void SpawnHill1()
    {
        Vector3 position = new Vector3(9, (float)rand.NextTriangular(Hill1_Height_Min, Hill1_Height_Max, (Hill1_Height_Min + Hill1_Height_Max) * .5), 0);
        var spawn = Instantiate(Hill1, position, Quaternion.identity) as GameObject;
        spawn.transform.parent = transform;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(Hill1_Depth_Min, Hill1_Depth_Max);
        Invoke("SpawnHill1", Random.Range(Hill1_Frequency_Min, Hill1_Frequency_Max));
    }
    void SpawnHill2()
    {
        Vector3 position = new Vector3(9, (float)rand.NextTriangular(Hill2_Height_Min, Hill2_Height_Max, (Hill2_Height_Min + Hill2_Height_Max) * .5), 0);
        var spawn = Instantiate(Hill2, position, Quaternion.identity) as GameObject;
        spawn.transform.parent = transform;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(Hill2_Depth_Min, Hill2_Depth_Max);
        Invoke("SpawnHill2", Random.Range(Hill2_Frequency_Min, Hill2_Frequency_Max));
    }
    void SpawnHill3()
    {
        Vector3 position = new Vector3(9, (float)rand.NextTriangular(Hill3_Height_Min, Hill3_Height_Max, (Hill3_Height_Min + Hill3_Height_Max) * .5), 0);
        var spawn = Instantiate(Hill3, position, Quaternion.identity) as GameObject;
        spawn.transform.parent = transform;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(Hill3_Depth_Min, Hill3_Depth_Max);
        Invoke("SpawnHill3", Random.Range(Hill3_Frequency_Min, Hill3_Frequency_Max));
    }
    void SpawnBush()
    {
        Vector3 position = new Vector3(9, Bush_Height, 0);
        var spawn = Instantiate(Bush, position, Quaternion.identity) as GameObject;
        spawn.transform.parent = transform;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(Bush_Depth_Min, Bush_Depth_Max);
        Invoke("SpawnBush", Random.Range(Bush_Frequency_Min, Bush_Frequency_Max));
    }
    void SpawnCloud()
    {
        Vector3 position = new Vector3(9, Random.Range(Cloud_Height_Min, Cloud_Height_Max), 0);
        var spawn = Instantiate(Cloud, position, Quaternion.identity) as GameObject;
        spawn.transform.parent = transform;
        spawn.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(Cloud_Depth_Min, Cloud_Depth_Max);
        Invoke("SpawnCloud", Random.Range(Cloud_Frequency_Min, Cloud_Frequency_Max));
    }
}
