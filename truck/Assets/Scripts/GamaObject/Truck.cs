using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EState
{
    None,
    Dead,
}
public class Truck : Unit
{
    public static Truck TestPlayer;
    public IReadOnlyList<Vector3> LainList => _lainList;
    public bool IsRightMove { get; private set; }
    public float truckSpeed = 0.3f;
    public float MaxHp { get; private set; } = 30;
    public float CurrentHp { get; private set; }
    public EState State { get; private set; }

    private List<Vector3> _lainList = new List<Vector3>();
    private int _currentLain = 0;
    private bool _isLeft = true;
    private void Awake()
    {
        TestPlayer = this;

        var list = new List<Vector3>()
        {
            new Vector3(0f, 3.2f, 0),
            new Vector3(1.15f, 2.6f, 0),
            new Vector3(2.3f, 2f, 0),
            new Vector3(3.45f, 1.4f, 0),
        };
        TestPlayer.transform.position = list[0];
        _lainList.AddRange(list);
        CurrentHp = MaxHp;
    }
    private void Start()
    {
        UpdateLanePosition();
    }

    public void UpdateLanePosition()
    {
        transform.position = _lainList[_currentLain];
    }
    public void GetFule()
    {
        CurrentHp += 5;
        if(CurrentHp > MaxHp )
        {
            CurrentHp = MaxHp;
        }
    }
    public void ChangeLane()
    {
        int nextLain = _currentLain;
        nextLain += _isLeft ? 1 : -1;
        if (nextLain >= _lainList.Count)
            _isLeft = false;
        else if (nextLain < 0)
            _isLeft = true;
        _currentLain += _isLeft ? 1 : -1;
    }
    private void Update()
    {
        if(State == EState.Dead) 
            return;
        CurrentHp -= Time.deltaTime;
        if (CurrentHp < 0)
        {
            ObjectiveEvent<string>.OnTruckFuleDown(new EventData<string>());
            OnTruckDead();
            return;
        }
        ObjectiveEvent<float>.OnTruckDictanceUpdate(new EventData<float>(truckSpeed));
        if(Input.GetMouseButtonDown(0))
        {
            IsRightMove = Camera.main.ScreenToViewportPoint(Input.mousePosition).x >= 0.5f;
            ChangeLane();
            UpdateLanePosition();
        }
    }
    private void OnTruckDead()
    {
        State = EState.Dead;
    }
}
