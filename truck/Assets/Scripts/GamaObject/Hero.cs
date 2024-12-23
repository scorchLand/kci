using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public bool IsLeft => vector.x > 0;
    public Vector3 vector { get; private set; } = Vector3.zero;
    public float Speed { get; private set; }
    private void OnEnable()
    {
        Speed = Random.Range(0, 1);
        vector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        ObjectiveEvent<float>.onTruckDistanceUpdate += OnTruckDistanUpdate;
    }
    private void OnDisable()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate -= OnTruckDistanUpdate;
    }
    void Update()
    {
        transform.position += vector * Time.deltaTime * Speed;
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
