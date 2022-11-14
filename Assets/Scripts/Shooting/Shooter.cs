using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnTransform;

    public static event Action pistolFire;

    public void Shoot()
    {
        var bullet = Instantiate(_projectilePrefab, _spawnTransform.position, _spawnTransform.rotation);
        bullet.GetComponent<Projectile>().Launch(_spawnTransform.forward);
        Destroy(bullet, _lifeTime);

        pistolFire?.Invoke();
    }
}
