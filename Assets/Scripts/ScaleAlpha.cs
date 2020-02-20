using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAlpha : MonoBehaviour
{
    AudioPeer audioPeer;
    Material material;
    Color origGlow;

    // Start is called before the first frame update
    void Start()
    {
        audioPeer = GameObject.Find("Audio").GetComponent<AudioPeer>();
        material = GetComponent<MeshRenderer>().material;
        origGlow = material.GetColor("_InnerGlowColor");
    }

    // Update is called once per frame
    void Update()
    {
        material.SetColor("_InnerGlowColor", Color.Lerp(material.GetColor("_InnerGlowColor"),
                                            new Color(origGlow.r, origGlow.g, origGlow.b, audioPeer.amplitudeBuffer / 1.0f),
                                            .5f));
    }
}
