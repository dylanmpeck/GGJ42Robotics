using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField] TextMesh text;

    string prompt1 = "Select A Song";
    string prompt2 = "Place Path with Right Hand Button";

    float timer;

    private void Start()
    {
        text.text = prompt1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3.0f)
            text.text = prompt2;
        
        if (timer >= 6.0f)
        {
            timer = 0.0f;
            text.text = prompt1;
        }

        timer += Time.deltaTime;
    }
}
