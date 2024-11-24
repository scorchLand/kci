using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public bool IsLeft => Vector.x > 0;
    public Vector3 Vector { get; private set; } = Vector3.zero;
    public float Speed = 10;
    public void SetVector(Vector3 vector, float speed)
    {
        Vector = vector;
        Speed = speed;
    }
    private void OnEnable()
    {
        Vector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        ObjectiveEvent<float>.onTruckDistanceUpdate += OnTruckDistanUpdate;
    }
    private void OnDisable()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate -= OnTruckDistanUpdate;
    }
    void Update()
    {
        transform.position += Vector * Time.deltaTime * Speed;
        if (Vector3.Distance(Truck.TestPlayer.transform.position, transform.position) < 1f)
            OnCrash();
        if (transform.position.y > 20)
            OnDisapoint();
    }
    private void OnTruckDistanUpdate(EventData<float> distance)
    {
        transform.position += BackgroundController.vector * Time.deltaTime * distance.data * 0.01f;
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
