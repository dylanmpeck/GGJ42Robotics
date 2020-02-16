using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    public List<GameObject> heartFrames;

    public List<Texture> heartTexes;

    Image image;

    int currentFrame = 36;
    int prevFrame = 36;

    public static bool forward = true;

    float time = 0.0f;

    public Material greenScreen;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Texture t in heartTexes)
        {
            GameObject go = new GameObject("HeartFrame" + i.ToString());
            go.transform.SetParent(this.transform);
            go.AddComponent<CanvasRenderer>();
            go.AddComponent<RectTransform>();
            go.GetComponent<RectTransform>().localPosition = Vector3.zero;
            go.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 400);
            go.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
            go.AddComponent<RawImage>();
            go.GetComponent<RawImage>().texture = t;
            go.GetComponent<RawImage>().material = greenScreen;
            heartFrames.Add(go);
            if (i != currentFrame)
                go.SetActive(false);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFrame == 0)
        {
            forward = true;
        }

        if (heartFrames.Count > 0 && currentFrame == heartFrames.Count - 1)
            forward = false;


        if (time > 0.1f)
        {
            if (forward)
            {
                currentFrame++;
                heartFrames[currentFrame].SetActive(true);
                if (currentFrame > 0) heartFrames[currentFrame - 1].SetActive(false);
            }
            //else if (!forward)
            //{
            //    currentFrame--;
            //    heartFrames[currentFrame].SetActive(true);
            //    if (currentFrame != heartFrames.Count - 1)
            //        heartFrames[currentFrame + 1].SetActive(false);
            //}
            time = 0.0f;
        }
        else
            time += Time.deltaTime;

        if (!forward)
        {
            //Debug.Log("Current frame: " + currentFrame);
            currentFrame = heartFrames.Count - 37 - (int)(GameManager.percentComplete * (heartFrames.Count - 37)) + 36;
            heartFrames[currentFrame].SetActive(true);
            if (prevFrame != currentFrame) heartFrames[prevFrame].SetActive(false);
        }
        prevFrame = currentFrame;
    }
}
