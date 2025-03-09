using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public float speed = 5;
    private void Update()
    {
        transform.Translate(-transform.position.normalized * Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, Vector3.zero) < 1)
            Destroy(gameObject);
    }
}
