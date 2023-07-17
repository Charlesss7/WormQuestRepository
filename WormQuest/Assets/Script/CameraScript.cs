using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(0.0f, 0.5f)]
    public float smoothSpeed;

    public Transform target;

    private Vector3 velocity;
    private void FixedUpdate(){
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), ref velocity, smoothSpeed);
    }
}
