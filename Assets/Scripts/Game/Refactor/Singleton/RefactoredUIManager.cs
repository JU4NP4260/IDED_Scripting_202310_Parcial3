public class RefactoredUIManager : UIManagerBase
{
    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.PlayerControllerInstance;
    protected override GameControllerBase GameController => RefactoredGameController.GameControllerInstance;

    public static RefactoredUIManager UIManagerInstance { get => uIManagerInstance; set => uIManagerInstance = value; }
    private static RefactoredUIManager uIManagerInstance;

    private void Awake()
    {
        if (uIManagerInstance == null)
        {
            uIManagerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    /*
    private static RefactoredUIManager GetInstance()
    {
        if (uIManagerInstance == null)
        {
            uIManagerInstance = new RefactoredUIManager();
        }
        return uIManagerInstance;
    }
    */
}