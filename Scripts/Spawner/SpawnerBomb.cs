using UnityEngine;

[RequireComponent(typeof(SpawnerObjectCounter))]

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;

    private Spawner<Bomb> _spawner;
    private SpawnerObjectCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<SpawnerObjectCounter>();
        _spawner = new Spawner<Bomb>(_bombPrefab, _counter);
    }

    public void Spawn(Vector3 spawnPosition)
    {
        Bomb bomb = _spawner.Spawn(spawnPosition);

        bomb.Died += ReturnBombInPool;

    }

    private void ReturnBombInPool(Bomb bomb)
    {
        _spawner.ReturnObjectInPool(bomb);
        bomb.Died -= ReturnBombInPool;
    }
}
