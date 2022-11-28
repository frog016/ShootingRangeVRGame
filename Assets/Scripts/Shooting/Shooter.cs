using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnTransform;

    public void Shoot()
    {
        var bullet = Instantiate(_projectilePrefab, _spawnTransform.position, _spawnTransform.rotation);
        bullet.GetComponent<Projectile>().Launch(_spawnTransform.forward, _projectileSpeed);
        Destroy(bullet, _lifeTime);
    }
}
