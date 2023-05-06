public class RefactoredUIManager : UIManagerBase
{
    protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    protected override GameControllerBase GameController => throw new System.NotImplementedException();

    private static RefactoredUIManager UIManagerInstance;

    private RefactoredUIManager() { }

    public static RefactoredUIManager GetInstance()
    {
        if (UIManagerInstance == null)
        {
            UIManagerInstance = new RefactoredUIManager();
        }
        return UIManagerInstance;
    }
}