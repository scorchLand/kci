using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int StageNumber { get; private set; } = 0;
    public IReadOnlyList<HeroTowerScore> ScoreList => _scoreList;

    public GameObject Hero;
    public GameObject enemy;
    public GameObject Tower;

    private List<HeroTowerScore> _scoreList = new List<HeroTowerScore>();

    private void Start()
    {
        _scoreList.Add(new HeroTowerScore());
        StartCoroutine(RoutineRandomSpawn());
    }
    private void Update()
    {
        if(StageSystem.Instance.CurrentTime > InGameController.Instance.stageSystem.maxTime)
        {
            StageSystem.Instance.SetCurrentTime(0);
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
