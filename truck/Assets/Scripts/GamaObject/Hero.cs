using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{

    void Update()
    {
        transform.position = transform.position += Vector3.up * Time.deltaTime;
        if (Vector3.Distance(Truck.TestPlayer.transform.position, transform.position) < 0.7f)
            OnCrash();
        if (transform.position.y > 20)
            OnCrash();
    }
    private void OnCrash()
    {
        Destroy(gameObject);
        ObjectiveEvent<long>.OnTruckCrash(new EventData<long>(1));
    }
}
