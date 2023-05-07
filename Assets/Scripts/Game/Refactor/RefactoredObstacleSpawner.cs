using UnityEngine;
using UnityEngine.Pool;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    [SerializeField] private PoolBase obstacleBluePool;
    [SerializeField] private PoolBase obstacleGreenPool;
    [SerializeField] private PoolBase obstacleRedPool;

    private int radomRange;
    int newMinX;

    public static RefactoredObstacleSpawner ObstacleSpawnerInstance { get => obstacleSpawnerInstance; set => obstacleSpawnerInstance = value; }
    private static RefactoredObstacleSpawner obstacleSpawnerInstance;

    private void Awake()
    {
        if (obstacleSpawnerInstance == null)
        {
            obstacleSpawnerInstance = this;
            //DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        radomRange = Random.Range(0, 3);
        newMinX = Random.Range(-6, 6);
    }

    protected override void Start()
    {
        base.Start();
        RefactoredGameController.GameOverEvent += OnGameOver;
    }

    /*
    private static RefactoredObstacleSpawner GetInstance()
    {
        if (obstacleSpawnerInstance == null)
        {
            obstacleSpawnerInstance = new RefactoredObstacleSpawner();
        }
        return obstacleSpawnerInstance;
    }
    */


    protected override void SpawnObject()
    {
        switch(radomRange)
        {
            case 0:
                GameObject proyectile1 = obstacleBluePool.RetrieveInstance();
                proyectile1.transform.position = new Vector2(newMinX, YPos);
                break;

            case 1:
                GameObject proyectile2 = obstacleGreenPool.RetrieveInstance();
                proyectile2.transform.position = new Vector2(newMinX, YPos);
                break;

            case 2:
                GameObject proyectile3 = obstacleRedPool.RetrieveInstance();
                proyectile3.transform.position = new Vector2(newMinX, YPos);
                break;
        }
    }
}