using System.Collections;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    private Coroutine waitSec;

    public PoolBase Pool { get => pool; set => pool = value; }
    private PoolBase pool;

    private void OnEnable()
    {
        if (waitSec != null) 
        {
            StopCoroutine(waitSec);
            waitSec = StartCoroutine(WaitSecReturnPool());
        }
        else if (waitSec == null)
        {
            waitSec = StartCoroutine(WaitSecReturnPool());
        }
    }


    public void RecycleObject()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
    }


    void OnObjectToRecycle(GameObject instance)
    {
        Pool.RecycleInstance(instance);
    }


    public void AssigPool(PoolBase pool)
    {
        this.pool = pool;
    }


    private IEnumerator WaitSecReturnPool()
    {
        yield return new WaitForSeconds(3);
        RecycleObject();
    }
}