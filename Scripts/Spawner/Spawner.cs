using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    private Pool<T> _pool = new Pool<T>();

    public int ActiveObject { get; private set; }

    public Spawner(T prefab, int maxCount)
    {
        _pool.CreateObject(prefab, maxCount);
    }

    public bool TrySpawn(Vector3 spawnPosition, out T t)
    {
        if (_pool.TryGetPoolObject(out t))
        {
            t.gameObject.SetActive(true);
            t.transform.position = spawnPosition;
            ActiveObject++;

            return true;
        }

        return false;
    }

    public void ReturnObjectInPool(T t)
    {
        _pool.AddObjectinPool(t);
        ActiveObject--;
    }
}