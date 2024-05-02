using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Unit
{
    private const float _laneOffet = -2;
    public static Truck TestPlayer;
    public bool IsRightMove {get; private set;}

    public int CurrentLane {get; private set;}
    private void Awake()
    {
        TestPlayer = this;
    }
    private void Start()
    {
        UpdateLanePosition();
        UpdateDierection();
    }

    public void UpdateDierection()
    {
        if(CurrentLane >= 4)
            IsRightMove = false;
        if(CurrentLane <= 0)
            IsRightMove = true;
    }

    public void UpdateLanePosition()
    {
        transform.position = new Vector3(CurrentLane + _laneOffet, 5, 0);
    }
    public void ChangeLane()
    {
        if (IsRightMove)
            CurrentLane++;
        else
            CurrentLane--;
        UpdateDierection();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeLane();
            UpdateLanePosition();
        }
    }
}
