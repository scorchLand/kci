using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputController.IsMouseDown)
        {
            Debug.Log($"{InputController.InputDistance}");
            var targetVector = transform.position + (InputController.InputDistance * speed * Time.deltaTime);
            if (TestWallController.IsTestBoxCollision(targetVector))
                transform.position = targetVector;
        }
    }
}
