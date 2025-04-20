using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance { get; private set; } 
    public float power = 5;

    private Rigidbody2D physic;

    private void Awake()
    {
        Instance = this;
        physic = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        InGameController.Instance.cameraController.SetTrackingTarget(transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        //Debug.Log(physic.velocity);
        bool isCollision = false;
        var force = InputController.InputDistance * power;
        if (!TestWallController.IsTestBoxCollision(transform.position + (new Vector3(physic.velocity.x, 0) * Time.fixedDeltaTime)))
        {
            physic.velocity = new Vector2(-physic.velocity.x, physic.velocity.y);
            isCollision = true;
        }
        if (!TestWallController.IsTestBoxCollision(transform.position + (new Vector3(0, physic.velocity.y) * Time.fixedDeltaTime)))
        {
            physic.velocity = new Vector2(physic.velocity.x, -physic.velocity.y);
            isCollision = true;
        }
        if (isCollision)
            return;
        if (InputController.IsMouseDown)
        {
            //Debug.Log($"{InputController.InputDistance}");
            //var targetVector = transform.position + (InputController.InputDistance * power * Time.deltaTime);
            //if (TestWallController.IsTestBoxCollision(targetVector))
            //    transform.position = targetVector;
            physic.AddForce(force);
        }
    }
    public void CreateTower()
    {
        var tower = Instantiate(InGameController.Instance.stageController.Tower);
        tower.transform.position = transform.position;
    }
}
