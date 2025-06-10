using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCamera
{
    public Camera Camera { get; private set; }
    public Transform TrackingTarget { get; private set; }
    public Vector3 TrackingPosition => TrackingTarget == null ? Vector3.zero : TrackingTarget.position;
    public Vector3 offset = new Vector3(0,0, -10);
    public void SetTrackingTarget(Transform target)
    {
        TrackingTarget = target;
    }
    public void SetCamera(Camera camera)
    {
        Camera = camera;
    }
    public void Update()
    {
        Camera.transform.position = TrackingPosition + offset;
    }
}
