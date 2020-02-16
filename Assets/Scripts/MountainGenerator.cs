using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainGenerator : MonoBehaviour
{
    public List<GameObject> mountainPrefabs;
    int collisionCount = 0;
    bool spawning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(collisionCount);
        //if (!spawning)
        SpawnGround();
    }

    void SpawnGround()
    {
        //spawning = true;
        //yield return new WaitForEndOfFrame();
        if (collisionCount == 0)
        {
            int idx = Random.Range(0, mountainPrefabs.Count);
            GameObject mountain = Instantiate(mountainPrefabs[idx], transform.position, transform.rotation);
            mountain.transform.Translate(0, 0, -0.1f, Space.World);
            //mountain.transform.localScale = Vector3.Scale(mountain.transform.localScale, new Vector3(0, Random.Range(-1, 1), 0));
        }
        //spawning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
    }
}
