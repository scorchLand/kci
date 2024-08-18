using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grooz;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        Tables.LoadFromResources();
    }
}
