using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FuleSpawner : MonoBehaviour 
{
    public Fule prefab;
    public bool IsActivate { get; private set; } = true;

    public float duration = 3;
    private void Awake()
    {
        StartCoroutine(RoutineSpawn());
    }

    private void Spawn(Vector3 targetPosition)
    {
        Instantiate(prefab);
        prefab.transform.position =targetPosition;
    }
    private IEnumerator RoutineSpawn()
    {
        while (IsActivate)
        {
            yield return new WaitForSeconds(duration);
            Spawn(new Vector3(Random.Range(-3f, 3f)-15, Random.Range(-1f, 1f)-6));
        }
        yield break;
    }
}
