using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The character to follow
    public float smoothSpeed = 0.125f;  // Smoothness of the camera movement
    public Vector3 offset;  // Offset of the camera

    void LateUpdate()
    {
        // Determine target position with offset
        Vector3 desiredPosition = target.position + offset;
        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Set the camera position
        transform.position = smoothedPosition;
    }
}
