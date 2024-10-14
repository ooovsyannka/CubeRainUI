using UnityEngine;

public class Spawner<T> where T : MonoBehaviour
{
    private Pool<T> _pool = new Pool<T>();
    private T _prefab;
    private SpawnerObjectCounter _counter;

    public Spawner(T prefab, SpawnerObjectCounter counter)
    {
        _prefab = prefab;
        _counter = counter;
    }

    public T Spawn(Vector3 spawnPosition)
    {
        T spawnableObject = _pool.GetObject(_prefab);

        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = spawnPosition;

        _counter.AddActiveObjectCount();
        _counter.AddCountSpawnedObject();
        _counter.TryChangeCountCreateObject(_pool.CreateObjectCount);

        return spawnableObject;
    }

    public void ReturnObjectInPool(T returnedObject)
    {
        _pool.AddObject(returnedObject);
        _counter.RemoveActiveObjectCount();
    }
}