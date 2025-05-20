using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int StageNumber { get; private set; } = 0;
    public IReadOnlyList<HeroTowerScore> ScoreList => _scoreList;

    public Unit Hero;
    public Unit enemy;
    public Unit Tower;

    private List<HeroTowerScore> _scoreList = new List<HeroTowerScore>();

    private void Start()
    {
        _scoreList.Add(new HeroTowerScore());
        _scoreList[0].AddValue(2);
        StartCoroutine(RoutineRandomSpawn());
    }
    private void Update()
    {
        if(InGameController.Instance.stageSystem.CurrentTime > InGameController.Instance.stageSystem.maxTime)
        {
            InGameController.Instance.stageSystem.SetCurrentTime(0);
            StageNumber++;
        }
    }
    private IEnumerator RoutineRandomSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            bool isTeam = StageNumber % 2 == 0;
            var newEnemy = Instantiate(isTeam ? Hero : enemy);
            newEnemy.SetTeam(isTeam ? ETeam.Third : ETeam.Second);
            newEnemy.transform.position = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 30);
        }
    }
}
