using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo
{
    public bool IsActivate { get; private set; }

    public float duration = 1;

    private void Spawn(Vector3 targetPosition)
    {

    }
    private IEnumerator RoutineSpawn()
    {
        while(IsActivate)
        {
            yield return new WaitForSeconds(duration);
        }
        yield break;
    }
}
