using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour
{
    [SerializeField] GameObject[] arrows;

    float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.30f)
            arrows[0].SetActive(true);
        if (timer >= .60f)
            arrows[1].SetActive(true);
        if (timer >= 1.0f)
            arrows[2].SetActive(true);

        if (timer >= 1.7f)
        {
            foreach (GameObject arrow in arrows)
                arrow.SetActive(false);
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
