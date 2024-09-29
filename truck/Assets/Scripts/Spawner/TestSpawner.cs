using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grooz;

public class TestSpawnTime
{
    public RowSpwaner Row;
    public float nextSpawnDistance;
    public string monsterKey;
    public bool isLoop;
    public TestSpawnTime(RowSpwaner row)
    {
        nextSpawnDistance = Random.Range(row.DistanceMin, row.DistanceMax);
        monsterKey = row.Monster;
        isLoop = true;
        Row = row;
    }
    public void Spawn(Hero[] hero, Transform contaner)
    {
        var target = GameObject.Instantiate(hero[Random.Range(0, hero.Length)], contaner);
        target.transform.position = new Vector3(-5, Random.Range(-1f, -4f), 0);
        nextSpawnDistance += Row.RepeatDistance;
    }
}
public class TestSpawner : MonoBehaviour
{
    public Transform Contaner;
    public Hero[] hero;

    private List<TestSpawnTime> _list = new List<TestSpawnTime>();
    private float _distance;

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
        InitializeSpwner();
        //StartCoroutine(RoutineSpawn());
    }
    private IEnumerator RoutineSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0f,2f));
            var target = Instantiate(hero[Random.Range(0,hero.Length)], Contaner);
            target.transform.position = new Vector3(-5, Random.Range(-1f,-4f), 0);
        }
    }
    public void InitializeSpwner()
    {
        foreach(var row in Tables.Spwaner.List)
        {
            var info = new TestSpawnTime(row);
            _list.Add(info);
        }
    }
    private void OnTruckDistanceUpdate(EventData<float> distance)
    {
        _distance += Time.deltaTime * distance.data;
        for (int i = 0; i<_list.Count; i++)
        {
            var info = _list[i];
            if (_distance > info.nextSpawnDistance)
            {
                info.Spawn(hero, Contaner);
                if(!info.isLoop)
                {
                    _list.Remove(info);
                    i--;
                }
            }
        }
    }
}
