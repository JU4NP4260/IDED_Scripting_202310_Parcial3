using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationsProtocol : MonoBehaviour, IObserver
{
    [SerializeField] private Subject playerInstance;
    [SerializeField] private Subject UIInstance;
    [SerializeField] private Subject gameInstance;
    public void OnNotify()
    {

    }

    private void OnEnable()
    {
        playerInstance.AddObserver(this);
    }

    private void OnDisable()
    {
        playerInstance.RemoveObserver(this);
    }
}
