using System;

public class RefactoredPlayerController : PlayerControllerBase
{
    private PoolBase pool;
    protected override bool NoSelectedBullet => throw new System.NotImplementedException();

    public static Action<int> UiBulletSwap;

    public static RefactoredPlayerController PlayerControllerInstance { get => playerControllerInstance; set => playerControllerInstance = value; }
    private static RefactoredPlayerController playerControllerInstance;

    private void Awake()
    {
        GetInstance();
    }

    /*
    private void Start()
    {
        NotifyObservers();
    }
    */

    private static RefactoredPlayerController GetInstance() 
    {
        if (playerControllerInstance == null)
        {
            playerControllerInstance = new RefactoredPlayerController();
        }
        return playerControllerInstance;
    }



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
                pool = PoolRedBullet;
                break;

            case 1:
                break;

            case 2:
                break;
        }
    }
}