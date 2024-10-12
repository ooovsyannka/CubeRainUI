using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class BombRenderer : MonoBehaviour
{
   [SerializeField] private float _duration;

    private Renderer _renderer;

    public event Action Disappeared;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color color = _renderer.material.color;
        float elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            float alpha = Mathf.MoveTowards(1f, 0f, elapsedTime / _duration);
            _renderer.material.color = new Color(color.r, color.g, color.b, alpha);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Disappeared?.Invoke();
    }
}