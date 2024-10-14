using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();

    public int CreateObjectCount { get; private set; }

    public T GetObject(T prefab)
    {
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();
        }

        return CreateObject(prefab);
    }

    public void AddObject(T returnedObject)
    {
        _pool.Enqueue(returnedObject);
    }
    
    private T CreateObject(T prefab)
    {
        T newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);

        CreateObjectCount++;

        return newObject;
    }
}
