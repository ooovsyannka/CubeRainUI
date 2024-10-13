using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _liveTime;

    public event Action<Bomb> Died;

    private void OnEnable()
    {
        StartCoroutine(LiveDuration());
    }

    private IEnumerator LiveDuration()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_liveTime);

        yield return waitTime;

        Died?.Invoke(this);
        gameObject.SetActive(false);
    }
}
