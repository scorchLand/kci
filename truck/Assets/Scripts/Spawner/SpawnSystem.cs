using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public IReadOnlyList<SpawnerInfo> List => _list;
    public IReadOnlyDictionary<string, SpawnerInfo> Dictionary => _dictionary;

    private List<SpawnerInfo> _list = new List<SpawnerInfo>();
    private Dictionary<string, SpawnerInfo> _dictionary = new Dictionary<string, SpawnerInfo>();

    public SpawnSystem()
    {
        for(int i = 0; i<Tables.Spwaner.Count;i++)
        {
            var info = new SpawnerInfo(Tables.Spwaner.List[i]);
            _list.Add(info);
            _dictionary.Add("", info);
            break;
        }
    }
    public void Initialize()
    {
    }
    public void Dispose()
    {

    }
    private void Update()
    {
        foreach(var info in _list)
        {
            info.Update();
        }
    }
}
