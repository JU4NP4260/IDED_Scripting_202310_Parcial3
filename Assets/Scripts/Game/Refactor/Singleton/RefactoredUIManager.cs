public class RefactoredUIManager : UIManagerBase
{
    protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();
    protected override GameControllerBase GameController => throw new System.NotImplementedException();

    public static RefactoredUIManager UIManagerInstance { get => uIManagerInstance; set => uIManagerInstance = value; }
    private static RefactoredUIManager uIManagerInstance;

    private void Awake()
    {
        GetInstance();
    }

    private static RefactoredUIManager GetInstance()
    {
        if (uIManagerInstance == null)
        {
            uIManagerInstance = new RefactoredUIManager();
        }
        return uIManagerInstance;
    }
}