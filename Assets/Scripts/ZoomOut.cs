using System.Collections;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomAmount = 1f;
    public float smoothTime = 0.5f;
    private float targetZoom;
    private float currentZoomVelocity;
    

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        targetZoom = mainCamera.fieldOfView;
    }

    public void ZoomOutSmoothly()
    {
        mainCamera.transform.position = new Vector3(5.02f, 14.98f, 6f);
        targetZoom += zoomAmount;
        StartCoroutine(ZoomCoroutine());
    }

    private IEnumerator ZoomCoroutine()
    {
        while (Mathf.Abs(mainCamera.fieldOfView - targetZoom) > 0.01f)
        {
            mainCamera.fieldOfView = Mathf.SmoothDamp(mainCamera.fieldOfView, targetZoom, ref currentZoomVelocity, smoothTime);
            yield return null;
        }
    }
}
