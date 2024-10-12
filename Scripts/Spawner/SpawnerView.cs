using TMPro;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    [SerializeField] private SpawnerObjectCounter _objectCounter;
    
    [SerializeField] private TextMeshProUGUI _countSpawnedObject;
    [SerializeField] private TextMeshProUGUI _countCreateObject;
    [SerializeField] private TextMeshProUGUI _countActiveObject;

    private void OnEnable()
    {
        _objectCounter.CreatedObject += ShowSpawnedCount;
        _objectCounter.ChanchedActiveObjectCount += ShowActiveObject;
        _objectCounter.ChangeCreateObjectCount += ShowCountAllObject;
    }

    private void OnDisable()
    {
        _objectCounter.CreatedObject -= ShowSpawnedCount;
        _objectCounter.ChanchedActiveObjectCount -= ShowActiveObject;
        _objectCounter.ChangeCreateObjectCount -= ShowCountAllObject;
    }

    private void ShowSpawnedCount(int spawnedCount)
    {
        _countSpawnedObject.text = $"КОЛИЧЕСТВО ЗАСПАВНЕННЫХ ОБЪЕКТОВ - {spawnedCount}";
    }

    private void ShowActiveObject(int activeObjectCount)
    {
        _countActiveObject.text = $"КОЛИЧЕСТВО АКТИВНЫХ ОБЪЕКТОВ - {activeObjectCount}";
    }

    private void ShowCountAllObject(int allCount)
    {
        _countCreateObject.text = $"КОЛИЧЕСТВО СОЗДАННЫХ ОБЪЕКТОВ - {allCount}";
    }
}