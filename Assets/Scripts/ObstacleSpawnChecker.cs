using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnChecker : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CollectibleGen")
            Generator.readyToSpawnCollectible = true;
        if (other.tag == "Generator")
        {
            Generator.readyToSpawn = true;
            Generator.readyToSpawnCollectible = true;
        }
    }
}
