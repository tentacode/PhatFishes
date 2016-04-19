using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class FullscreenButton : Button, IPointerDownHandler
{
    new public GameObject camera;

	new public void OnPointerDown (PointerEventData eventData)
	{
        camera.GetComponent<CameraSize>().ToggleFullscreen();
	}
}
