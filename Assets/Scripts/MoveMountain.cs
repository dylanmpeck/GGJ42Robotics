using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMountain : MonoBehaviour
{
    float t = 0.0f;
    Vector3 initialScale;
    Vector3 secondScale;
    Vector3 thirdScale;
    Vector3 topScale;

    float bpm = 80;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        secondScale = new Vector3(initialScale.x, initialScale.y + 0.1f, initialScale.z);
        thirdScale = new Vector3(initialScale.x, initialScale.y + 0.3f, initialScale.z);
        topScale = new Vector3(initialScale.x, initialScale.y + .5f, initialScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += -transform.forward * GameManager.moveSpeed * Time.deltaTime;

       
        t += Time.deltaTime / (60 / bpm);
        if (t >= (60f / bpm))
            t = 0;
        this.transform.localScale = cubeBezier3(initialScale, topScale, thirdScale, secondScale, t);
    }

    public static Vector3 cubeBezier3(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (((-p0 + 3 * (p1 - p2) + p3) * t + (3 * (p0 + p2) - 6 * p1)) * t + 3 * (p1 - p0)) * t + p0;
    }
}
