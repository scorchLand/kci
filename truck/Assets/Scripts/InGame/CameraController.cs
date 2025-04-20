using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform TrackingTarget { get; private set; }
    public Vector3 TrackingPosition => TrackingTarget == null ? Vector3.zero : TrackingTarget.position;
    public Vector3 offset = new Vector3(0,0, -10);
    public void SetTrackingTarget(Transform target)
    {
        TrackingTarget = target;
    }
    private void Update()
    {
        transform.position = TrackingPosition + offset;
    }
}
