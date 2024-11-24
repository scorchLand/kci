using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo
{
    public RowSpwaner Row { get; private set; }
    public bool IsActivate { get; private set; }

    public float duration = 1;

    public SpawnerInfo(RowSpwaner row)
    { 
        Row = row;
    }
    public void Update()
    {

    }
    private void Spawn(Vector3 targetPosition)
    {

    }
    private IEnumerator RoutineSpawn()
    {
        while (IsActivate)
        {
            yield return new WaitForSeconds(duration);
        }
        yield break;
    }
}
