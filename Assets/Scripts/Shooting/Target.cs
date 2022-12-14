using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Target : MonoBehaviour
{
    [SerializeField] private float _maxScore;
    [SerializeField] private Transform _center;
    [SerializeField] private ScoreStorage _scoreStorage;

    public UnityEvent OnProjectileHitEvent;

    private Vector3 _size;

    private void Awake()
    {
        _size = GetComponent<BoxCollider>().size;
    }

    private void OnCollisionEnter(Collision otherCollision)
    {
        var projectile = otherCollision.gameObject.GetComponent<Projectile>();
        if (projectile == null)
            return;

        OnProjectileHitEvent.Invoke();
        var projectileContact = otherCollision.contacts.FirstOrDefault(contact => contact.otherCollider == otherCollision.collider);
        IncreaseScore(projectileContact.point);
    }

    private void IncreaseScore(Vector3 contactPoint)
    {
        var distanceToCenter = (_center.position - contactPoint).magnitude;

        var maxDistanceToCenter = ((Vector2)_center.position - (Vector2)_size).magnitude;
        var givenScore = _maxScore * (maxDistanceToCenter - distanceToCenter);

        _scoreStorage.ChangeScore((int)givenScore);
    }
}
