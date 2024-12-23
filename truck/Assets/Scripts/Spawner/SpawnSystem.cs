using Grooz;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSystem
{
    public IReadOnlyList<SpawnerInfo> List => _list;
    public IReadOnlyDictionary<string, SpawnerInfo> Dictionary => _dictionary;

    private List<SpawnerInfo> _list = new List<SpawnerInfo>();
    private Dictionary<string, SpawnerInfo> _dictionary = new Dictionary<string, SpawnerInfo>();
    private List<SpawnerInfo> _spawnList = new List<SpawnerInfo>();

    public SpawnSystem()
    {
        Initialize();
    }
    public void Initialize()
    {
        for (int i = 0; i < Tables.Spwaner.Count; i++)
        {
            var info = new SpawnerInfo(Tables.Spwaner.List[i]);
            _list.Add(info);
            _spawnList.Add(info);
            _dictionary.Add(info.Row.Key, info);
        }
    }
    public void Dispose()
    {

    }
    public void RemoveSpawnList(SpawnerInfo info)
    {
        _spawnList.Remove(info);
    }
    public void Update()
    {
        for (int i = 0; i < _spawnList.Count; i++)
        {
            var info = _spawnList[i];
            info.Update(InGameController.Instance.Distance);
        }
    }
}
