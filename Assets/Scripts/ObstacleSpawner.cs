using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject DrTPrefab;
    public int DrTWeight;
    public Queue<GameObject> DrTCache = new Queue<GameObject>();

    public GameObject DoublePipePrefab;
    public int DoublePipeWeight;
    public Queue<GameObject> DoublePipeCache = new Queue<GameObject>();

    public GameObject FloorPipePrefab;
    public int FloorPipeWeight;
    public Queue<GameObject> FloorPipeCache = new Queue<GameObject>();

    public GameObject CeilingPipePrefab;
    public int CeilingPipeWeight;
    public Queue<GameObject> CeilingPipeCache = new Queue<GameObject>();

    public float frequencyMin;
    public float frequencyMax;
    public float frequencyMean;

    private int totalWeight;

    private System.Random rand = new System.Random();

    void Start()
    {
        totalWeight = DrTWeight + DoublePipeWeight + CeilingPipeWeight + FloorPipeWeight;
        Invoke("SpawnObstacle", (float)rand.NextTriangular(frequencyMin, frequencyMax, frequencyMean));
    }

    void SpawnObstacle()
    {
        int chance = Random.Range(0, totalWeight);

        if ( 0 <= chance && chance < DrTWeight)
        {
            //spawn dr T
            CreateSpawn(DrTPrefab, DrTCache, new Vector3(8, 0, 0));
        }
        else if (DrTWeight <= chance && chance < DoublePipeWeight + DrTWeight)
        {
            //spawn double pipe
            CreateSpawn(DoublePipePrefab, DoublePipeCache, new Vector3(8, Random.Range(-.25f, 1.3f), 0));
        }
        else if (DoublePipeWeight + DrTWeight <= chance && chance < CeilingPipeWeight + DoublePipeWeight + DrTWeight)
        {
            //spawn ceiling pipe
            CreateSpawn(CeilingPipePrefab, CeilingPipeCache, new Vector3(8, Random.Range(2, 3.25f), 0));
        }
        else if (CeilingPipeWeight + DoublePipeWeight + DrTWeight <= chance && chance < FloorPipeWeight + CeilingPipeWeight + DoublePipeWeight + DrTWeight)
        {
            //spawn floor pipe
            CreateSpawn(FloorPipePrefab, FloorPipeCache, new Vector3(8, Random.Range(-2.25f, -1), 0));
        }

        Invoke("SpawnObstacle", (float)rand.NextTriangular(frequencyMin, frequencyMax, frequencyMean));
    }

    void CreateSpawn(GameObject prefab, Queue<GameObject> cache, Vector3 position)
    {
        GameObject spawn;
        if (cache.Count > 0)
        {
            spawn = cache.Dequeue();
            spawn.transform.position = position;
        }
        else
        {
            spawn = Instantiate(prefab, position, Quaternion.identity) as GameObject;
            spawn.transform.parent = transform;
            spawn.GetComponent<DoodadMovement>().Cache = cache;
        }
    }
}
