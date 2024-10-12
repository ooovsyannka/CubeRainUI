using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();

    public void CreateObject(T prefab, int maxLength)
    {
        for (int i = 0; i < maxLength; i++)
        {
            T t = Instantiate(prefab);
            _pool.Enqueue(t);
            t.gameObject.SetActive(false);
        }
    }

    public bool TryGetPoolObject(out T t)
    {
        t = null;

        if (_pool.Count != 0)
        {
            t = _pool.Dequeue();

            return true;
        }

        return false;
    }

    public void AddObjectinPool(T t)
    {
        _pool.Enqueue(t);
    }

    public int GetActiveCountObject()
    {
        return _pool.Count;
    }
}
