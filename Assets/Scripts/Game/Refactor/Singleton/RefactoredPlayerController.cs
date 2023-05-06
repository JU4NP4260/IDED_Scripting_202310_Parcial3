public class RefactoredPlayerController : PlayerControllerBase
{
    protected override bool NoSelectedBullet => throw new System.NotImplementedException();

    private static RefactoredPlayerController playerControllerInstance;

    private RefactoredPlayerController() { }

    public static RefactoredPlayerController GetInstance() 
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
    }
}