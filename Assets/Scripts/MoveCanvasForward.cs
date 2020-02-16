using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvasForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position += -Vector3.forward * GameManager.moveSpeed * Time.deltaTime;
    }
}
