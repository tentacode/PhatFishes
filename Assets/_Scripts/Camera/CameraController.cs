using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float zoomFactor = 2;
    private GameObject target;

	public void Focus(GameObject _target)
	{
        target = _target;

        GetComponent<CameraSize>().ScalePixel(zoomFactor);
	}

	void Update()
	{
        if (target == null) {
            return;
        }

        transform.position = target.transform.position;
	}
}
