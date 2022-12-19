using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float _cooldownTime;

    private bool _isReady;

    private void Awake()
    {
        _isReady = true;
    }

    public bool TryRestartCooldown()
    {
        if (!_isReady)
            return false;

        _isReady = false;
        StartCoroutine(WaitCooldownTime());

        return true;
    }

    private IEnumerator WaitCooldownTime()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _isReady = true;
    }
}