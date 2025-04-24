using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroTower : Unit
{
    public Bullet bullet;
    public float cooldown = 1;
    public float damage = 1;
    public float bulletSpeed = 1;
    public float site = 5;

    private float _cooldown = 0;

    private void Update()
    {
        _cooldown += Time.deltaTime;
        if(_cooldown > cooldown)
        {
            var enemy = GetEnemyPosition();
            if (enemy == null)
                return;
            _cooldown = 0;
            var cloneBullet = Instantiate(bullet);
            cloneBullet.transform.position = transform.position;
            cloneBullet.Initialize(damage, bulletSpeed, enemy.transform.position);
        }
    }
    private Unit GetEnemyPosition()
    {
        var list = UnitManager.UnitList.Where(a => a.Team == ETeam.Second).ToList();
        foreach(var enemy in list)
        {
            if(Vector3.Distance(enemy.transform.position, transform.position) < site)
            {
                return enemy;
            }
        }
        return null;
    }
}
