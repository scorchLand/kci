using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHeroInfo : UiComponent
{
    public UiHeroInfoCell prefab;
    private List<UiHeroInfoCell> _list = new List<UiHeroInfoCell>();
    public void Initialize()
    {
        ObjectiveEvent<string>.onPeapleHit += OnPeapleHit;
    }
    public void UpdateUi()
    {
        var towerCount = InGameController.Instance.stageController.ScoreList[0].Count;
        Debug.Log($"{towerCount}");
        if (towerCount > _list.Count)
        {
            for (int i = 0; i < towerCount - _list.Count; i++)
            {
                var info = Instantiate(prefab);
                info.gameObject.SetActive(true);
                info.Initialize(this);
                info.transform.SetParent(transform);
                _list.Add(info);
            }
        }

    }
    public void RemoveList(UiHeroInfoCell cell)
    {
        _list.Remove(cell);
        Destroy(cell.gameObject);
    }
    private void OnPeapleHit(EventData<string> data)
    {
        UpdateUi();
    }
}
