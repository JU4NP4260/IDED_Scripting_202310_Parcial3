using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;

    private static RefactoredObstacleSpawner ObstacleSpawnerInstance;

    private RefactoredObstacleSpawner() { }

    public static RefactoredObstacleSpawner GetInstance()
    {
        if (ObstacleSpawnerInstance == null)
        {
            ObstacleSpawnerInstance = new RefactoredObstacleSpawner();
        }
        return ObstacleSpawnerInstance;
    }

    protected override void SpawnObject()
    {
        throw new System.NotImplementedException();
    }
}