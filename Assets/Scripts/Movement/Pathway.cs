using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathway : MonoBehaviour, IEnumerable<Transform>
{
    [SerializeField] private Transform[] _points;

    public Transform First => _points.First();

    public IEnumerator<Transform> GetEnumerator()
    {
        return _points.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}