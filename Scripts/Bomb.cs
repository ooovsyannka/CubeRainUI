using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _liveTime;

    public event Action<Bomb> Died ;

    private void OnEnable()
    {
        StartCoroutine(LiveDuretion());
    }

    private IEnumerator LiveDuretion()
    {
        yield return new WaitForSeconds(_liveTime);

        Died?.Invoke(this);
        gameObject.SetActive(false);
    }
}
