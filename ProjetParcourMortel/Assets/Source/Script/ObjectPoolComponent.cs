using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class ObjectPoolComponent : MonoBehaviour
{
    public GameObject objectToPool;
    public int poolSize = 20;
    private ObjectPool<GameObject> objectPool;
    public bool isReady = false;

    public GameObject GetObject() => objectPool.GetObject();
    public void PutObject(GameObject objectToPut) => objectPool.PutObject(objectToPut);

    private void Awake()
    {
        DontDestroyOnLoad(this);
        objectPool = new ObjectPool<GameObject>();
        var namePrefix = objectToPool.name;
        StartCoroutine(FillPool());
    }

    private IEnumerator FillPool()
    {
        var namePrefix = objectToPool.name;
        for (int i = 0; i < poolSize; ++i)
        {
            var newObject = Instantiate(objectToPool, transform);
            newObject.GetComponent<IPoolable>().AssociatedPool = this;
            newObject.name = $"{namePrefix} {i}";
            newObject.SetActive(false);
            objectPool.PutObject(newObject);
            if (i % 500 == 0)
            {
                yield return null;
            }
        }
        isReady = true;
    }
}
