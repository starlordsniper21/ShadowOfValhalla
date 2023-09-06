using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraflollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }



}
