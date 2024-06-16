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
            yield return new WaitForSeconds(Random.Range(0f,2f));
            var target = Instantiate(hero[Random.Range(0,hero.Length)]);
            target.transform.position = new Vector3(Random.Range(-4.12f, 4.12f), -20, 0);
        }
    }
}
