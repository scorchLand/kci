using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        StartCoroutine(RoutineRandomSpawn());
    }
    private IEnumerator RoutineRandomSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            var newEnemy = Instantiate(enemy);
            newEnemy.transform.position = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 15);
        }
    }
}
