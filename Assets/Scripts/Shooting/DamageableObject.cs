using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
