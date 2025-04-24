using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public float hp = 1;
    public float speed = 5;
    public Vector3 TrackingPosition { get; private set; }
    private Coroutine _routineAboid;
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 aver = Vector2.zero;
        foreach(var point in collision.contacts)
        {
            aver += point.point;
        }
        aver = aver/collision.contacts.Length;
        TrackingPosition = Quaternion.AngleAxis(150f, Vector3.forward) * aver - transform.position;
        if (_routineAboid == null)
            _routineAboid = StartCoroutine(Aboid(collision));
    }
    private void Update()
    {
        transform.Translate(TrackingPosition - transform.position.normalized * Time.deltaTime * speed);
        if(Vector3.Distance(transform.position, TrackingPosition) < 1)
            Destroy(gameObject);
    }
    public void OnDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Dead();
        }

    }
    private void Dead()
    {
        Destroy(gameObject);
    }
    private IEnumerator Aboid(Collision2D collision)
    {
        yield return new WaitForSeconds(1f);
        TrackingPosition = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        _routineAboid = null;
    }
}
