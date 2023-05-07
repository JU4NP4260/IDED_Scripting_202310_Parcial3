using System;
using Unity.VisualScripting;
using UnityEngine;

public sealed class RefactoredGameController : GameControllerBase
{
    [SerializeField] private RefactoredUIManager uiManager;
    [SerializeField] private RefactoredPlayerController playerController;
    [SerializeField] private RefactoredObstacleSpawner obstacleSpawner;

    public static event Action GameOverEvent;
    public static event Action UiUpdateScore;
    public static event Action<int> PlayerUpdateScore;
    public static event Action<int> ObstacleDestroyedEvent;

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.PlayerControllerInstance;
    protected override UIManagerBase UiManager => RefactoredUIManager.UIManagerInstance;
    protected override ObstacleSpawnerBase Spawner => RefactoredObstacleSpawner.ObstacleSpawnerInstance;

    public static RefactoredGameController GameControllerInstance { get => gameControllerInstance; set => gameControllerInstance = value; }
    private static RefactoredGameController gameControllerInstance;

    private void Awake()
    {
        if (gameControllerInstance == null)
        {
            gameControllerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

        ObstacleDestroyedEvent += OnObstacleDestroyed;
    }


    /*
    private static RefactoredGameController GetInstance()
    {
        if (gameControllerInstance == null)
        {
            gameControllerInstance = new RefactoredGameController();
        }
        return gameControllerInstance;
    }
    */


    protected override void OnObstacleDestroyed(int hp) 
    {
        //NotifyObservers();

        if(UiUpdateScore != null) { UiUpdateScore(); }
        if(PlayerUpdateScore != null) { PlayerUpdateScore(hp); }

    }

    protected override void SetGameOver()
    {
        if(GameOverEvent != null) { GameOverEvent(); }
        base.SetGameOver();
    }

    protected override void OnScoreChanged(int scoreAdd)
    {
        throw new NotImplementedException();
    }
}