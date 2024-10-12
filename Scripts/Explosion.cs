using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;
    [SerializeField] private BombRenderer _bombRenderer;
    [SerializeField] private ExplosionEffect _explosionEffect;

    private void OnEnable()
    {
        _explosionEffect.gameObject.SetActive(false);
        _bombRenderer.Disappeared += Explode;
    }

    private void OnDisable()
    {
        _bombRenderer.Disappeared -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            explodableObject.AddExplosionForce(GetExplodeForce(explodableObject.transform), transform.position, _explodeRadius);
        }

        _explosionEffect.gameObject.SetActive(true);
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explodeRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    private float GetExplodeForce(Transform objectPosition)
    {
        int divisionDistance = 10;
        float distance = Vector3.Distance(transform.position, objectPosition.position) / divisionDistance;

        return _explodeForce / distance;
    }
}