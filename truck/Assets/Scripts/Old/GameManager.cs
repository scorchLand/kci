using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grooz;

public interface ISystemComponent
{
    void Initialize();
    void Dispose();
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public InputController InputController { get; private set; }
    public IngameCamera IngameCamera { get; private set; }

    public LobbyConroller LobbyConroller { get; private set; }
    public IngameController IngameController { get; private set; }

    private List<ISystemComponent> _systemComponent = new List<ISystemComponent>();
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Initialize();
    }
    private void OnDestroy()
    {
        Dispose();
    }
    public void InitializeConroller()
    {
        InputController = new InputController();
        IngameCamera = new IngameCamera();

        LobbyConroller = new LobbyConroller();
        IngameController = new IngameController();

        IngameCamera.SetCamera(Camera.main);

        _systemComponent.Add(LobbyConroller);
        _systemComponent.Add(IngameController);
    }
    public void InitializeManager()
    {

    }

    public void Initialize()
    {
        Tables.LoadFromResources();

        foreach(var component in _systemComponent)
        {
            component.Initialize();
        }
    }

    public void Dispose()
    {
        foreach (var component in _systemComponent)
        {
            component.Dispose();
        }
    }
    private void Update()
    {
        InputController.Update();
    }
}
