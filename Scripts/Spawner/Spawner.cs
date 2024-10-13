using UnityEngine;

public class Spawner<T> where T : MonoBehaviour
{
    private Pool<T> _pool = new Pool<T>();

    public int ActiveObject { get; private set; }

    public Spawner(T prefab, int maxCount)
    {
        _pool.CreateObject(prefab, maxCount);
    }

    public bool TrySpawn(Vector3 spawnPosition, out T spawnableObject)
    {
        if (_pool.TryGetPoolObject(out spawnableObject))
        {
            spawnableObject.gameObject.SetActive(true);
            spawnableObject.transform.position = spawnPosition;
            ActiveObject++;

            return true;
        }

        return false;
    }

    public void ReturnObjectInPool(T returnedObject)
    {
        _pool.AddObjectinPool(returnedObject);
        ActiveObject--;
    }
}