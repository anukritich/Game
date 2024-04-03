using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlidingSystem : MonoBehaviour
{
    [SerializeField] private float MaxThrustSpeed = 400;
    [SerializeField] private float ThrustFactor = 80;
    [SerializeField] private float DragFactor = 1;
    [SerializeField] private float MinDrag;
    [SerializeField] private float RotationSpeed = 5;
    [SerializeField] private float LowPercent = 0.1f, HighPercent = 1;
    [SerializeField] private float SpeedFactor = 1; // New speed factor variable
    [SerializeField] private float GlideVelocity = 10f;
    [SerializeField] private Animator animator;
    




    private float CurrentThrustSpeed;
    private float TiltValue, LerpValue;

    private Transform CameraTransform;
    private Rigidbody Rb;

    private void Start()
    {
        CameraTransform = Camera.main.transform.parent;
        Rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GlidingMovement();
    }

    private void Update()
    {
        ManageRotation();
    }

    private void GlidingMovement()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("StaminaEmpty"))
        {
            // Animation is playing, disable gliding
            //Rb.useGravity = true;// Enable gravity to make the character fall
            Rb.velocity = new Vector3(0, -10f, 0);
            LoadNextScene();


            return;
        }
        float pitchInDeg = transform.eulerAngles.x % 360;
        float pitchInRads = transform.eulerAngles.x * Mathf.Deg2Rad;
        float mappedPitch = -Mathf.Sin(pitchInRads);
        float offsetMappedPitch = Mathf.Cos(pitchInRads) * DragFactor;
        float accelerationPercent = pitchInDeg >= 300f ? LowPercent : HighPercent;
        Vector3 glidingForce = -Vector3.right * CurrentThrustSpeed * SpeedFactor;

        CurrentThrustSpeed += mappedPitch * accelerationPercent * ThrustFactor * Time.deltaTime * SpeedFactor;
        CurrentThrustSpeed = Mathf.Clamp(CurrentThrustSpeed, 0, MaxThrustSpeed * SpeedFactor);

        Vector3 velocity = transform.forward * GlideVelocity * SpeedFactor; // Set the glide velocity here
        Rb.velocity = velocity;

        Rb.drag = Mathf.Clamp(offsetMappedPitch, MinDrag, DragFactor);

        Debug.Log(CurrentThrustSpeed);
    }



    private void ManageRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX == 0 && mouseY == 0)
        {
            TiltValue = Mathf.Lerp(TiltValue, 0, LerpValue);
            LerpValue += Time.deltaTime;
            //TiltValue += mouseY * RotationSpeed * Time.deltaTime;
            //TiltValue = Mathf.Clamp(TiltValue, minTiltAngle, maxTiltAngle);
        }
        
        else
        {
            LerpValue = 0;
        }

        Quaternion targetRotation = Quaternion.Euler(CameraTransform.eulerAngles.x, CameraTransform.eulerAngles.y, TiltValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
    private void LoadNextScene()
    {
        StartCoroutine(DelayLoad());
    }
    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(3f); // Delay for 1.2 seconds
        SceneManager.LoadScene("Start"); // Load the "Start" scene
    }
}