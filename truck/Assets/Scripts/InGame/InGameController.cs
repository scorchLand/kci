using Grooz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    public static InGameController Instance { get; private set; }
    public StageSystem stageSystem;
    public StageController stageController;
    public UiMainCanvas mainCanvas;
    public float Distance { get; private set; }

    private void Awake()
    {
        Tables.LoadFromResources();
        Instance = this;
    }
    private void OnDestroy()
    {
    }
    private void Update()
    {

    }
}
