using System;
using UnityEngine;

public class SpawnerObjectCounter : MonoBehaviour
{
    private int _countSpawned;
    private int _activeObjectCount;
    private int _createObjectCount;

    public event Action<int> CreatedObject;
    public event Action<int> ChanchedActiveObjectCount;
    public event Action<int> ChangeCreateObjectCount;

    public void AddCountSpawnedObject()
    {
        _countSpawned++;
        CreatedObject?.Invoke(_countSpawned);
    }

    public void AddActiveObjectCount()
    {
        _activeObjectCount++;
        ChanchedActiveObjectCount?.Invoke(_activeObjectCount);
    }

    public void RemoveActiveObjectCount()
    {
        _activeObjectCount--;
        ChanchedActiveObjectCount?.Invoke(_activeObjectCount);
    }

    public void TryChangeCountCreateObject(int createObjectCount)
    {
        if (_createObjectCount < createObjectCount)
        {
            _createObjectCount = createObjectCount;
            ChangeCreateObjectCount?.Invoke(_createObjectCount);
        }
    }
}
