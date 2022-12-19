using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private SpawnData _data;
    [SerializeField] private Pathway[] _pathways;

    private bool _isLaunched;

    public void StartSpawning()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        if (_isLaunched)
            yield break;

        _isLaunched = true;
        for (var _ = 0; _ < _data.Count; _++)
        {
            Spawn();
            yield return new WaitForSeconds(_data.Delay);
        }

        _isLaunched = false;
    }

    private void Spawn()
    {
        var pathway = _pathways[Random.Range(0, _pathways.Length)];
        var target = Instantiate(_targetPrefab, pathway.First.position, Quaternion.identity);
        target.GetComponent<PathwayMovement>().StartMoving(pathway);
    }
}
