using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Unit
{
    public float speed = 5;
    private Rigidbody2D physic;

    private Vector3 TargetDistance;
    private void Awake()
    {
        physic = GetComponent<Rigidbody2D>();
        StartCoroutine(RoutineRand());
    }
    private void Update()
    {
        transform.Translate(-transform.position.normalized * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, Vector3.zero) < 1)
            Destroy(gameObject);
        if (physic.velocity != Vector2.zero)
            return;
        var targetPosition = TargetDistance * Time.deltaTime;
        if (TestWallController.IsTestBoxCollision(targetPosition + transform.position))
            transform.position += targetPosition;
    }
    private void FixedUpdate()
    {
        bool isCollision = false;
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
        {
            physic.AddForce(-transform.position);
            return;
        }
    }
    private IEnumerator RoutineRand()
    {
        while (true)
        {
            TargetDistance = new Vector3(Random.Range(-5, 5f), Random.Range(-5, 5f)).normalized;
            yield return new WaitForSeconds(Random.Range(0, 5f));
        }
    }
}
