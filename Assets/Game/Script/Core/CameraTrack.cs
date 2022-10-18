using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;//higher this value is our camera will faster move
    public Vector3 offset;
    void LateUpdate()
    {
        Vector3 desired_position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desired_position, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);

    }
}
