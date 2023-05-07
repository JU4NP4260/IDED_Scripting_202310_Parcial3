using System;
using System.Collections.Generic;

public abstract class RefactoredObstacle : ObstacleBase
{
    protected override GameControllerBase GameController => RefactoredGameController.GameControllerInstance;
    public static Action<int> OnDestroyAction;

    private void OnEnable()
    {
        RefactoredGameController.ObstacleDestroyedEvent += OnDestroyAction;
    }

    private void OnDisable()
    {
        RefactoredGameController.ObstacleDestroyedEvent -= OnDestroyAction;
    }

    protected override void DestroyObstacle(bool sendingMessage = false)
    {
        if (sendingMessage)
        {
            if (OnDestroyAction != null)
            {
                OnDestroyAction(HP);
            }
        }

        GetComponent<Ipoolable>().Recycle();
    }

}