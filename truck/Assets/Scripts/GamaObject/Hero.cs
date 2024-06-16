using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public bool IsLeft { get; private set; } = true;
    public float Speed { get; private set; }
    private void OnEnable()
    {
        Speed = Random.Range(0, 10);
        IsLeft = Random.Range(0, 2) == 1 ? true : false;
        ObjectiveEvent<float>.onTruckDistanceUpdate += OnTruckDistanUpdate;
    }
    private void OnDisable()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate -= OnTruckDistanUpdate;
    }
    void Update()
    {
        transform.position += (IsLeft ? Vector3.left : Vector3.right) * Time.deltaTime * Speed;
        if (Vector3.Distance(Truck.TestPlayer.transform.position, transform.position) < 2f)
            OnCrash();
        if (transform.position.y > 20)
            OnDisapoint();
    }
    private void OnTruckDistanUpdate(EventData<float> distance)
    {
        transform.position += Vector3.up * Time.deltaTime * distance.data;
    }
    private void OnCrash()
    {
        Destroy(gameObject);
        ObjectiveEvent<long>.OnTruckCrash(new EventData<long>(1));
    }
    private void OnDisapoint()
    {
        Destroy(gameObject);
    }
}
