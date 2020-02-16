using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoDebug : MonoBehaviour
{
    VideoPlayer vp;
    bool rewind;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += ReverseVideo;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rewind);
        if (rewind) 
        {
            vp.time = vp.time - Time.deltaTime;
            vp.frame -= 10;
        }


    }

    void ReverseVideo(UnityEngine.Video.VideoPlayer videoplayer)
    {
        rewind = true;
        videoplayer.frame = (long)videoplayer.frameCount - 1;
    }
}
