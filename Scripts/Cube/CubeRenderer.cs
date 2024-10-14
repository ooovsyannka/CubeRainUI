using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(CubeCollision))]

public class CubeRenderer : MonoBehaviour
{
    private CubeCollision _detector;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _detector = GetComponent<CubeCollision>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.cyan;
        _detector.Collided += SetRandomColor;
    }

    private void OnDisable()
    {
        _detector.Collided -= SetRandomColor;
    }

    private void SetRandomColor()
    {
        float maxValue = 1.0f;
        float randomValueR = GetRandomNumber(0, maxValue);
        float randomValueG = GetRandomNumber(0, maxValue);
        float randomValueB = GetRandomNumber(0, maxValue);

        _renderer.material.color = new Color(randomValueR, randomValueB, randomValueG);
    }

    private float GetRandomNumber(float minNumber, float maxNumver)
    {
        return Random.Range(minNumber, maxNumver);
    }
}