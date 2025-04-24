using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : FuncObj
{
    public float lifeTime = 1;
    private float _damage = 1;
    private float _speed = 1;
    private Vector3 _targetPosition;
    private float _lifeTime = 0;
    public void Initialize(float damage, float speed, Vector3 targetPosition)
    {
        _damage = damage;
        _speed = speed;
        _targetPosition = targetPosition;

        _lifeTime = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.OnDamage(_damage);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        transform.Translate((_targetPosition - transform.position).normalized * _speed * deltaTime);
        _lifeTime += deltaTime;
        if (_lifeTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
