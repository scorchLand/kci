using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public static StageSystem Instance { get; private set; }

    public float CurrentTime { get; private set; } = 0;

    public float maxTime = 60;
    public int currentStage = 0;

    public void Initialize()
    {
        if (Instance == null)
            return;
    }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Update()
    {
        CurrentTime += Time.deltaTime;
    }
}
