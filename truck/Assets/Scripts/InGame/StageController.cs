using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int StageNumber { get; private set; } = 0;

    public GameObject Hero;
    public GameObject enemy;

    private float _currentTime = 0;
    private void Start()
    {
        StartCoroutine(RoutineRandomSpawn());
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime > 10)
        {
            _currentTime = 0;
            StageNumber++;
        }
    }
    private IEnumerator RoutineRandomSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            var newEnemy = Instantiate(StageNumber % 2 ==0 ? Hero : enemy);
            newEnemy.transform.position = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 15);
        }
    }
}
