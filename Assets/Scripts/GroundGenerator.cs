﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject quadPrefab;
    int collisionCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(collisionCount);
        //if (needToSpawn)
        //{
            SpawnGround();
        //}
    }

    void SpawnGround()
    {
        //spawning = true;
        //yield return new WaitForEndOfFrame();
        if (collisionCount == 0)
        {
            //Debug.Log("Spawn");
            GameObject ground = Instantiate(quadPrefab, transform.position, transform.rotation);
            ground.transform.Translate(0, 0, -0.2f, Space.World);
            ground.transform.SetParent(transform);
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
