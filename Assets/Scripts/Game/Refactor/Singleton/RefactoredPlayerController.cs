using System;

public class RefactoredPlayerController : PlayerControllerBase
{
    private PoolBase pool;
    protected override bool NoSelectedBullet => pool == null;

    public static Action<int> UiBulletSwap;

    public static RefactoredPlayerController PlayerControllerInstance { get => playerControllerInstance; set => playerControllerInstance = value; }
    private static RefactoredPlayerController playerControllerInstance;

    private void Awake()
    {
        if (playerControllerInstance == null)
        {
            playerControllerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }


    protected override void Start()
    {
        //NotifyObservers();

        base.Start();
        GameOverNotifications();
    }


    private void GameOverNotifications()
    {
        RefactoredGameController.GameOverEvent += OnGameOver;
        RefactoredGameController.PlayerUpdateScore += UpdateScore;
    }

    /*    useless implementation
    private static RefactoredPlayerController GetInstance() 
    {
        if (playerControllerInstance == null)
        {
            playerControllerInstance = new RefactoredPlayerController();
        }
        return playerControllerInstance;
    }
    */

    protected override void Shoot()
    {
        //base.Shoot(); 
    }

    protected override void SelectBullet(int index)
    {
        //base.SelectBullet(index);

        switch (index)
        {
            case 0:
                pool = RedBulletPool.Instance;
                break;

            case 1:
                pool = GreenBulletPool.Instance;
                break;

            case 2:
                pool = BlueBulletPool.Instance;
                break;

        }

        if (UiBulletSwap != null) { UiBulletSwap(index); }
    }
}