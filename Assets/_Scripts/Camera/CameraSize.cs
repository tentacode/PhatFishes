using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour
{
    public int pixelScaling = 6;

    private int PIXEL_PER_UNIT = 10;

    void Start()
    {
        Camera camera = GetComponent<Camera>();
        camera.orthographicSize = Screen.height * 0.5f / (pixelScaling * PIXEL_PER_UNIT);
    }
}
