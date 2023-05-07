using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObstaclePool : PoolBase
{
    public static BlueObstaclePool Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;
    }
}