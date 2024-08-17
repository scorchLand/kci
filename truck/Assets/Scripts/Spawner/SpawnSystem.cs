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
        while (true)
        {
            var info = new SpawnerInfo();
            _list.Add(info);
            _dictionary.Add("", info);
        }
    }
    public void Initialize()
    {
    }
    public void Dispose()
    {

    }
}
