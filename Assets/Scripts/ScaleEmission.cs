using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEmission : MonoBehaviour
{
    [SerializeField] AudioPeer audioPeer;
    Material material;
    Color origEmissiveColor;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<LineRenderer>().material;
        origEmissiveColor = material.GetColor("_EmissiveColor");
    }

    // Update is called once per frame
    void Update()
    {
        material.SetColor("_EmissiveColor", new Color(origEmissiveColor.r * audioPeer.amplitudeBuffer,
                                                       origEmissiveColor.g * audioPeer.amplitudeBuffer,
                                                       origEmissiveColor.b * audioPeer.amplitudeBuffer));
    }
}
