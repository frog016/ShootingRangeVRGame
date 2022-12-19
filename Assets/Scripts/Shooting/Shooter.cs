using UnityEngine;

[RequireComponent(typeof(Cooldown))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnTransform;

    private Cooldown _cooldown;

    private void Awake()
    {
        _cooldown = GetComponent<Cooldown>();
    }

    public void Shoot()
    {
        if (!_cooldown.TryRestartCooldown())
            return;

        var bullet = Instantiate(_projectilePrefab, _spawnTransform.position, _spawnTransform.rotation);
        bullet.GetComponent<Projectile>().Launch(_spawnTransform.forward, _projectileSpeed);
        Destroy(bullet, _lifeTime);
    }
}
