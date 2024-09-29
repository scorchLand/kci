using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Unit
{
    public static Truck TestPlayer;
    public IReadOnlyList<Vector3> LainList => _lainList;
    public bool IsRightMove { get; private set; }
    public float truckSpeed = 0.3f;

    private List<Vector3> _lainList = new List<Vector3>();
    private int _currentLain = 0;
    private bool _isLeft = true;
    private void Awake()
    {
        TestPlayer = this;

        var list = new List<Vector3>()
        {
            new Vector3(1.15f, 1f, 0),
            new Vector3(1.725f, 0.7f, 0),
            new Vector3(2.3f, 0.4f, 0),
        };
        TestPlayer.transform.position = list[0];
        _lainList.AddRange(list);
    }
    private void Start()
    {
        UpdateLanePosition();
    }

    public void UpdateLanePosition()
    {
        Debug.Log(_currentLain);
        transform.position = _lainList[_currentLain];
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
        ObjectiveEvent<float>.OnTruckDictanceUpdate(new EventData<float>(truckSpeed));
        if(Input.GetMouseButtonDown(0))
        {
            IsRightMove = Camera.main.ScreenToViewportPoint(Input.mousePosition).x >= 0.5f;
            ChangeLane();
            UpdateLanePosition();
        }
    }
}
