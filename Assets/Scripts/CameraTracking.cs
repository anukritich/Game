
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;

    [SerializeField] private float SmoothTime;
    [SerializeField] private float Sensitivity;
    public float rotationSpeed = 5.0f;
    private float mouseX, mouseY;

    [SerializeField] private Vector3 Offset;
    private Vector3 CurrentVelocity;

    private void FixedUpdate()
    {
        FollowTargetTransform();
    }
    private void Update()
    {
        CameraRotation();
    }

    private void FollowTargetTransform()
    {
        Vector3 desiredPosition = PlayerTransform.position + Offset;
        Vector3 positionInterpolation = Vector3.SmoothDamp(transform.position, desiredPosition, ref CurrentVelocity, SmoothTime);

        transform.position = positionInterpolation;
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed, Space.Self);
       



    }

}