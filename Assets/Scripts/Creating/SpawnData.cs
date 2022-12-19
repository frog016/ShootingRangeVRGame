using UnityEngine;

[CreateAssetMenu(menuName = "Creating/Spawn/Data", fileName = "SpawnData")]
public class SpawnData : ScriptableObject
{
    [SerializeField] private float _delay;
    [SerializeField] private int _count;

    public float Delay => _delay;
    public int Count => _count;
}
