using UnityEngine;

public class ContinuousRotator : MonoBehaviour
{
    public float rotateSpeed = 45f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
