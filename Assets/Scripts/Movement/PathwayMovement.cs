using System.Collections;
using UnityEngine;

public class PathwayMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitingTime;
    [SerializeField] private Transform[] _pathway;

    public void StartMoving()
    {
        StartCoroutine(MoveThroughPathwayCoroutine());
    }

    private IEnumerator MoveThroughPathwayCoroutine()
    {
        foreach (var point in _pathway)
        {
            while (!AreClosetToPoint(point))
            {
                MoveTo(point);
                yield return null;
            }

            yield return new WaitForSeconds(_waitingTime);
        }
    }

    private void MoveTo(Transform point)
    {
        var direction = point.position - transform.position;
        transform.position += direction * _speed * Time.deltaTime;
    }

    private bool AreClosetToPoint(Transform transform)
    {
        return Vector3.Distance(this.transform.position, transform.position) < 1e-5;
    }
}
