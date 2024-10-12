using System;
using UnityEngine;

public class SpawnerObjectCounter : MonoBehaviour 
{
    private int _countSpawned;
    
    public event Action<int> CreatedObject;
    public event Action<int> ChanchedActiveObjectCount;
    public event Action<int> ChangeCreateObjectCount;

    public void AddCountSpawn()
    {
        _countSpawned++;
        CreatedObject?.Invoke(_countSpawned);
    }

    public void ChangeActiveObjectCount(int count)
    {
        ChanchedActiveObjectCount?.Invoke(count);
    }

    public void GetCountCreateObject(int count)
    {
        ChangeCreateObjectCount?.Invoke(count);
    }
}
