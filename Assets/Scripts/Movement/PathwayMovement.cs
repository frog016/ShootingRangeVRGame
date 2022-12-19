using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PathwayMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitingTime;

    public UnityEvent OnPathEndedEvent;

    public void StartMoving(Pathway pathway)
    {
        StartCoroutine(MoveThroughPathwayCoroutine(pathway));
    }

    private IEnumerator MoveThroughPathwayCoroutine(Pathway pathway)
    {
        foreach (var point in pathway)
        {
            while (!AreClosetToPoint(point))
            {
                MoveTo(point);
                yield return null;
            }

            yield return new WaitForSeconds(_waitingTime);
        }

        OnPathEndedEvent.Invoke();
    }

    private void MoveTo(Transform point)
    {
        var direction = point.position - transform.position;
        transform.position += direction * _speed * Time.deltaTime;
    }

    private bool AreClosetToPoint(Transform transform)
    {
        return Vector3.Distance(new Vector3(this.transform.position.x, 0, this.transform.position.z), transform.position) < 1e-5;
    }
}
