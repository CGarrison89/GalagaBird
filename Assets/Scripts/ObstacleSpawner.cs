using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject DrTPrefab;
    public int DrTWeight;

    public GameObject DoublePipePrefab;
    public int DoublePipeWeight;

    public GameObject FloorPipePrefab;
    public int FloorPipeWeight;

    public GameObject CeilingPipePrefab;
    public int CeilingPipeWeight;

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
            Instantiate(DrTPrefab, new Vector3(8, 0, 0), Quaternion.identity);
        }
        else if (DrTWeight <= chance && chance < DoublePipeWeight + DrTWeight)
        {
            //spawn double pipe
            Instantiate(DoublePipePrefab, new Vector3(8, Random.Range(-.25f, 1.3f), 0), Quaternion.identity);
        }
        else if (DoublePipeWeight + DrTWeight <= chance && chance < CeilingPipeWeight + DoublePipeWeight + DrTWeight)
        {
            //spawn ceiling pipe
            Instantiate(CeilingPipePrefab, new Vector3(8, Random.Range(2, 3.25f), 0), Quaternion.identity);
        }
        else if (CeilingPipeWeight + DoublePipeWeight + DrTWeight <= chance && chance < FloorPipeWeight + CeilingPipeWeight + DoublePipeWeight + DrTWeight)
        {
            //spawn floor pipe
            Instantiate(FloorPipePrefab, new Vector3(8, Random.Range(-2.25f, -1), 0), Quaternion.identity);
        }

        Invoke("SpawnObstacle", (float)rand.NextTriangular(frequencyMin, frequencyMax, frequencyMean));
    }
}
