using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Unit
{
    private const float interval = 2.06f;
    private const float _laneOffet = -4.12f;
    public static Truck TestPlayer;
    public bool IsRightMove {get; private set;}
    public float truckSpeed = 1;

    public int CurrentLane {get; private set;}
    private void Awake()
    {
        TestPlayer = this;
    }
    private void Start()
    {
        UpdateLanePosition();
    }

    public void UpdateLanePosition()
    {
        transform.position = new Vector3((CurrentLane * interval) + _laneOffet, 7, 0);
    }
    public void ChangeLane()
    {
        CurrentLane += IsRightMove ? 1 : -1;
        if (CurrentLane > 4)
            CurrentLane = 4;
        if (CurrentLane < 0)
            CurrentLane = 0;
    }
    private void Update()
    {
        ObjectiveEvent<float>.OnTruckDictanceUpdate(new EventData<float>(truckSpeed));
        if(Input.GetMouseButtonDown(0))
        {
            IsRightMove = Camera.main.ScreenToViewportPoint(Input.mousePosition).x >= 0.5f;
            ChangeLane();
            UpdateLanePosition();
        }
    }
}
