using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<Transform> spawnLocations;
    public GameObject cubePrefab;
    float time = 0f;

    int currentLane = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 2.0f)
        {
            time = 0;
            Transform t = spawnLocations[Random.Range(0, spawnLocations.Count)];
            Instantiate(cubePrefab, t.position, t.rotation);
        }
        else
        {
            time += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            Camera.main.transform.position = new Vector3(spawnLocations[currentLane].transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 3)
        {
            currentLane++;
            Camera.main.transform.position = new Vector3(spawnLocations[currentLane].transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }
}
