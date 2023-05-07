using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    [SerializeField] private PoolBase obstacleLowPool;
    [SerializeField] private PoolBase obstacleMidPool;
    [SerializeField] private PoolBase obstacleHardPool;

    public static RefactoredObstacleSpawner ObstacleSpawnerInstance { get => obstacleSpawnerInstance; set => obstacleSpawnerInstance = value; }
    private static RefactoredObstacleSpawner obstacleSpawnerInstance;

    private void Awake()
    {
        GetInstance();
    }

    private static RefactoredObstacleSpawner GetInstance()
    {
        if (obstacleSpawnerInstance == null)
        {
            obstacleSpawnerInstance = new RefactoredObstacleSpawner();
        }
        return obstacleSpawnerInstance;
    }

    protected override void SpawnObject()
    {
        throw new System.NotImplementedException();
    }
}