using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnerObjectCounter))]

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private SpawnerBomb _spawnBomb;
    [SerializeField] private float _delay;

    private Spawner<Cube> _spawner;
    private SpawnerObjectCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<SpawnerObjectCounter>();
        _spawner = new Spawner<Cube>(_cubePrefab, _counter);
    }

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while (enabled)
        {
            Cube cube = _spawner.Spawn(GetrandomSpawnPosition());

            cube.GetSpawnerBomb(_spawnBomb);
            cube.Died += ReturnCubeInPool;

            yield return new WaitForSeconds(_delay);
        }
    }

    private void ReturnCubeInPool(Cube cube)
    {
        _spawner.ReturnObjectInPool(cube);
        cube.Died -= ReturnCubeInPool;
    }

    private Vector3 GetrandomSpawnPosition()
    {
        float division = 2f;
        float randomPositionX = GetRandomNumber(0, _spawnPosition.localScale.x / division);
        float randomPositionZ = GetRandomNumber(0, _spawnPosition.localScale.z / division);
        float maxHeight = 25;
        float height = _spawnPosition.position.y + maxHeight;

        return new Vector3(randomPositionX, height, randomPositionZ);
    }

    private float GetRandomNumber(float minNumber, float maxNumver)
    {
        return Random.Range(minNumber, maxNumver);
    }
}
