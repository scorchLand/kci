using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance { get; private set; }
    public Transform pivot;
    public float power = 5;
    public Animation anim;

    private Rigidbody2D _physic;
    private bool _isMove = false;

    private void Awake()
    {
        Instance = this;
        _physic = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        InGameController.Instance.cameraController.SetTrackingTarget(transform);
        SetMoveState(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetMoveState(InputController.InputDistance != Vector3.zero);
    }
    private void FixedUpdate()
    {
        //Debug.Log(physic.velocity);
        bool isCollision = false;
        var force = InputController.InputDistance * power;
        if (!TestWallController.IsTestBoxCollision(transform.position + (force * Time.fixedDeltaTime)))
        {
            isCollision = true;
        }
        if (!TestWallController.IsTestBoxCollision(transform.position + (force * Time.fixedDeltaTime)))
        {
            isCollision = true;
        }
        if (isCollision)
            return;

        if (InputController.IsMouseDown)
        {

            if (InputController.InputDistance == Vector3.zero)
                return;

            transform.Translate(force * Time.fixedDeltaTime);

            if (force.x < 0)
            {
                pivot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                pivot.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    }
    public Unit CreateTower()
    {
        var tower = Instantiate(InGameController.Instance.stageController.Tower);
        return tower;
    }
    private void SetMoveState(bool on)
    {
        if (on == _isMove)
            return;
        _isMove = on;
        anim.clip = anim.GetClip(_isMove ? "main_1" : "main_1_idle");
        anim.Play();
    }
}
