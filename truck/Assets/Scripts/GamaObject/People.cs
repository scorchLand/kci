using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPeopleState
{
    None,
    Idle,
    Dead,
}
public class People : Unit
{
    public EPeopleState State { get; private set; }
    public float speed = 5;
    private Rigidbody2D physic;

    private Vector3 TargetDistance;
    private void Awake()
    {
        physic = GetComponent<Rigidbody2D>();
        StartCoroutine(RoutineRand());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartCoroutine(RoutineOnEnterCollision());

    }
    private void Update()
    {
        if (State == EPeopleState.Dead)
            return;
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
    private IEnumerator RoutineOnEnterCollision()
    {
        State = EPeopleState.Dead;
        yield return new WaitForSeconds(0.5f);
        InGameController.Instance.stageController.ScoreList[0].AddValue(0.1f);
        Destroy(gameObject);
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
