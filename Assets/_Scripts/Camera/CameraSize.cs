using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour
{
    private int PIXEL_PER_UNIT = 10;

    void Start()
    {
        ScalePixel(1);
    }

    public void ScalePixel(float factor)
    {
        int pixelScaling = Mathf.FloorToInt(Screen.height / 256);

        if (Mathf.FloorToInt(Screen.width / 512) < pixelScaling) {
            pixelScaling = Mathf.FloorToInt(Screen.width / 512);
        }

        pixelScaling = Mathf.RoundToInt(pixelScaling * factor);

        Camera camera = GetComponent<Camera>();
        camera.orthographicSize = Screen.height * 0.5f / (pixelScaling * PIXEL_PER_UNIT);
    }
}
