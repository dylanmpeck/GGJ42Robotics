using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<Transform> spawnLocations;
    public GameObject cubePrefab;
    public GameObject hourglassPrefab;
    public GameObject cubeSpawnChecker;
    float time = 0f;
    public static bool readyToSpawn = true;
    public static bool readyToSpawnCollectible = true;

    int currentLane = 1;

    List<bool> laneUsed = new List<bool>();

    bool spawnedMiddleTime;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform loc in spawnLocations)
        {
            laneUsed.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
/*        float tMult = 1.0f;
        if (GameManager.moveSpeed > 0)
            tMult = (15.0f - (GameManager.moveSpeed / 15.0f)) / 15.0f;*/

        if (readyToSpawn && !GameManager.begin)
        {
            readyToSpawn = false;
            //spawnedMiddleTime = false;
            //time = 0;
            int totalObstacles = GetTotalObstacles();
            for (int i = 0; i < totalObstacles; i++)
            {
                Transform t = spawnLocations[GetRandomLane()];
                GameObject cube = Instantiate(cubePrefab, t.position, t.rotation);
                cube.transform.SetParent(transform);
            }
            Transform spawnCheckerTrans = spawnLocations[spawnLocations.Count / 2];
            GameObject go = Instantiate(cubeSpawnChecker, spawnCheckerTrans.position, spawnCheckerTrans.rotation);
            go.transform.SetParent(transform);
        }
        if (readyToSpawnCollectible && !GameManager.begin)
        {
            readyToSpawnCollectible = false;
            //spawnedMiddleTime = true;
            Transform timeTransform = spawnLocations[GetRandomLane()];
            GameObject h = Instantiate(hourglassPrefab, timeTransform.position, timeTransform.rotation);
            h.transform.SetParent(transform);
        }
        else
        {
            time += Time.deltaTime;
        }
        ResetUsedLanes();
    }

    int GetRandomLane()
    {
        int lane = -1;
        while (lane == -1 || laneUsed[lane] == true)
        {
            lane = Random.Range(0, spawnLocations.Count);
        }
        laneUsed[lane] = true;
        return lane;
    }

    int GetTotalObstacles()
    {
        float roll = Random.Range(0.0f, 1.0f);
        if (roll >= .80f)
            return 3;
        if (roll >= .5f)
            return 2;
        return 1;
    }

    void ResetUsedLanes()
    {
        for (int i = 0; i < laneUsed.Count; i++)
            laneUsed[i] = false;
    }
}
