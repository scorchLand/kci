using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grooz;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Initialize();
    }
    private void OnDestroy()
    {
        Dispose();
    }

    public void Initialize()
    {
        Tables.LoadFromResources();
    }

    public void Dispose()
    {

    }
}
