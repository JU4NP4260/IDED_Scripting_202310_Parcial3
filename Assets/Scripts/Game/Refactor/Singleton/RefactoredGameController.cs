using UnityEngine;

public sealed class RefactoredGameController : GameControllerBase
{
    [SerializeField]
    private RefactoredUIManager uiManager;

    [SerializeField]
    private RefactoredPlayerController playerController;

    [SerializeField]
    private RefactoredObstacleSpawner obstacleSpawner;

    protected override PlayerControllerBase PlayerController => playerController;

    protected override UIManagerBase UiManager => uiManager;

    protected override ObstacleSpawnerBase Spawner => obstacleSpawner;

    private static RefactoredGameController GameControllerInstance;

    private RefactoredGameController() { }

    public static RefactoredGameController GetInstance()
    {
        if (GameControllerInstance == null)
        {
            GameControllerInstance = new RefactoredGameController();
        }
        return GameControllerInstance;
    }

    protected override void OnScoreChanged(int hp)
    {
        throw new System.NotImplementedException();
    }


}