using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    [SerializeField]
    private int count;

    [SerializeField]
    private GameObject basePrefab;

    int randomNumber;

    private List<GameObject> instances = new List<GameObject>();

    private void Start()
    {
        randomNumber = Random.Range(1, 3);
        PopulatePool();
    }

    public void RecycleInstance(GameObject instance)
    {
        if (instance != null)
        {
            instance.transform.position = transform.position;
            instance.transform.rotation = Quaternion.identity;
            instance.SetActive(false);
            instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            instances.Add(instance);
        }
    }

    public virtual GameObject RetrieveInstance()
    {
        for (int i = 0; i < count; i++)
        {
            instances.Add(Instantiate(basePrefab, transform.position, Quaternion.identity));
            instances[i].SetActive(false);
            return instances[i];
        }
        return null;
    }

    private void PopulatePool()
    {
        for (int i = 0; i < count;  ++i)
        {
            instances.Add(Instantiate(basePrefab, transform.position, Quaternion.identity));
            instances[i].SetActive(true);   
        }
    }
}