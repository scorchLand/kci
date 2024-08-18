using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grooz;

public class TestSpawner : MonoBehaviour
{
    public Transform Contaner;
    public Hero[] hero;

    private List<RowSpawner> _list = new List<RowSpawner>();
    private void Awake()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate += OnTruckDistanceUpdate;
    }
    private void OnDestroy()
    {
        ObjectiveEvent<float>.onTruckDistanceUpdate -= OnTruckDistanceUpdate;
    }
    private void Start()
    {
        StartCoroutine(RoutineSpawn());
    }
    private IEnumerator RoutineSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0f,2f));
            var target = Instantiate(hero[Random.Range(0,hero.Length)], Contaner);
            target.transform.position = new Vector3(Random.Range(-4.12f, 4.12f), -20, 0);
        }
    }
    public void InitializeSpwner()
    {

    }
    private void OnTruckDistanceUpdate(EventData<float> distance)
    {

    }
}
