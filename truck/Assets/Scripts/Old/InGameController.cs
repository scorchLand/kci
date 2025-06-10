using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    public static InGameController Instance { get; private set; }
    public IngameCamera cameraController;
    public StageSystem stageSystem;
    public StageController stageController;
    public UiMainCanvas mainCanvas;
    public float Distance { get; private set; }

    public GameObject[] TowerArray;

    private void Awake()
    {
        Tables.LoadFromResources();
        Instance = this;

        stageSystem.Initialize();
        mainCanvas.Initialize();
    }
    private void OnDestroy()
    {
    }
    private void Update()
    {

    }
}
