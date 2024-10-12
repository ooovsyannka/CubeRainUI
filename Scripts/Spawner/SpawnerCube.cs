using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnerObjectCounter))]

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private SpawnerBomb _spawnBomb;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _delay;

    private Spawner<Cube> _spawner;
    private SpawnerObjectCounter _counter;
    private bool _isWork = true;

    private void Awake()
    {
        _spawner = new Spawner<Cube>(_cubePrefab, _maxCount);
        _counter = GetComponent<SpawnerObjectCounter>();
    }

    private void Start()
    {
        _counter.GetCountCreateObject(_maxCount);
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while (_isWork != false)
        {
            if (_spawner.TrySpawn(GetrandomSpawnPosition(), out Cube cube))
            {
                cube.GetSpawnerBomb(_spawnBomb);
                cube.Died += ReturnCubeInPool;

                _counter.AddCountSpawn();
                _counter.ChangeActiveObjectCount(_spawner.ActiveObject);
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    private void ReturnCubeInPool(Cube cube)
    {
        _spawner.ReturnObjectInPool(cube);
        cube.Died -= ReturnCubeInPool;
        _counter.ChangeActiveObjectCount(_spawner.ActiveObject);
    }

    private Vector3 GetrandomSpawnPosition()
    {
        float division = 2f;
        float randomPositionX = GetRandomNumber(0, _spawnPosition.localScale.x / division);
        float randomPositionZ = GetRandomNumber(0, _spawnPosition.localScale.z / division);
        float maxHeight = 20;
        float height = _spawnPosition.position.y + maxHeight;

        return new Vector3(randomPositionX, height, randomPositionZ);
    }

    private float GetRandomNumber(float minNumber, float maxNumver)
    {
        return Random.Range(minNumber, maxNumver);
    }
}
