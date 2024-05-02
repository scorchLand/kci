using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{

    void Update()
    {
        transform.position = transform.position += Vector3.up * Time.deltaTime;
        if (Vector3.Distance(Truck.TestPlayer.transform.position, transform.position) < 0.7f)
            Destroy(gameObject);
        if(transform.position.y > 20)
            Destroy(gameObject);
    }
}
