using UnityEngine;

[RequireComponent(typeof(SpawnerObjectCounter))]

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private int _maxCount;

    private Spawner<Bomb> _spawner;
    private SpawnerObjectCounter _counter;

    private void Awake()
    {
        _spawner = new Spawner<Bomb>(_bombPrefab, _maxCount);
        _counter = GetComponent<SpawnerObjectCounter>();
    }

    private void Start()
    {
        _counter.GetCountCreateObject(_maxCount);
    }

    public void Spawn(Vector3 spawnPosition)
    {
        if (_spawner.TrySpawn(spawnPosition, out Bomb bomb))
        {
            bomb.Died += ReturnBombInPool;

            _counter.AddCountSpawn();
            _counter.ChangeActiveObjectCount(_spawner.ActiveObject);
        }
    }

    private void ReturnBombInPool(Bomb bomb)
    {
        _spawner.ReturnObjectInPool(bomb);
        bomb.Died -= ReturnBombInPool;

        _counter.ChangeActiveObjectCount(_spawner.ActiveObject);
    }
}
