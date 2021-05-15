using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().targetCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
