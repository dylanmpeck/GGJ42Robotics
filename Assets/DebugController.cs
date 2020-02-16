using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    public Text debugText;
    float yPos;
    bool up;

    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (up && transform.localPosition.y > yPos)
        {
            up = !up;
            yPos = transform.localPosition.y;
            GameManager.moveSpeed += .32f;
        }
        else if (!up && transform.localPosition.y < yPos)
        {
            up = !up;
            yPos = transform.localPosition.y;
            GameManager.moveSpeed += .32f;
        }
        else
            GameManager.moveSpeed -= .002f;
    }
}
