﻿using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubeRenderer), typeof(CubeCollision), typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private const float MaxLifeTime = 6;
    private const float MinLifeTime = 2;

    private WaitForSeconds _waitForSeconds;
    private CubeCollision _detector;
    private SpawnerBomb _spawnerBomb;
    private Rigidbody _rigidbody;

    public event Action<Cube> Died;

    private void Awake()
    {
        _detector = GetComponent<CubeCollision>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        _detector.Collided += Die;
    }

    private void OnDisable()
    {
        _detector.Collided -= Die;
    }

    public void GetSpawnerBomb(SpawnerBomb spawnerBomb)
    {
        _spawnerBomb = spawnerBomb;
    }

    private void Die()
    {
        StartCoroutine(CountdownToDie());
    }

    private IEnumerator CountdownToDie()
    {
        _waitForSeconds = new WaitForSeconds(UnityEngine.Random.Range(MinLifeTime, MaxLifeTime));

        yield return _waitForSeconds;

        Died?.Invoke(this);
        _spawnerBomb.Spawn(transform.position);
        gameObject.SetActive(false);
    }
}
