using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private float defaultWidth;
    private Camera camera;


    private void Start()
    {
        camera = Camera.main;

        defaultWidth = camera.orthographicSize * camera.aspect;
    }

    private void Update()
    {
        camera.orthographicSize = defaultWidth / camera.aspect;
    }
}
