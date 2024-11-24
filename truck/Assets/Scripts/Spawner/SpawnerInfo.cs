using DevDev.Extensions;
using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo
{
    public RowSpwaner Row { get; private set; }
    public bool IsActivate { get; private set; }

    public float NextSpawnDistance { get; private set; } = 0;
    public int CurrentSpawnCount { get; private set; } = 0;

    public SpawnerInfo(RowSpwaner row)
    { 
        Row = row;

        NextSpawnDistance = Row.DistanceMin;
    }
    public void Update(float distance)
    {
        if (distance > Row.DistanceMax)
        {
            InGameController.Instance.spawnSystem.RemoveSpawnList(this);
            return;
        }
        else if (distance > NextSpawnDistance)
        {
            NextSpawnDistance += Row.RepeatDistance;
            var spawnRate = Random.Range(0, Row.Rate);
            if (spawnRate < Row.Rate)
            {
                Spawn();
            }
        }
    }
    private void Spawn()
    {
        var hero = InGameController.Instantiate(Resources.Load<Hero>($"Prefabs/Monster/{Row.Prefabs}"));
        var floatInfo = Row.Lood.StringToFloatArray();
        var targetPosition = new Vector3(floatInfo[0], floatInfo[1], floatInfo[2]);
        hero.transform.position = targetPosition;
    }
    private IEnumerator RoutineSpawn()
    {
        while (IsActivate)
        {

        }
        yield break;
    }
}
