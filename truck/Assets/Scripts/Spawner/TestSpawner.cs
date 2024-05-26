using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public Hero[] hero;
    private void Start()
    {
        StartCoroutine(RoutineSpawn());
    }
    private IEnumerator RoutineSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0,5));
            var target = Instantiate(hero[Random.Range(0,hero.Length)]);
            target.transform.position = new Vector3(Random.Range(-2f, 2f), -7, 0);
        }
    }
}
