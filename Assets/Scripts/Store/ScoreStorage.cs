using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Store/Storage/Score", fileName = "ScoreStorage")]
public class ScoreStorage : ScriptableObject
{
    public int CurrentScore { get; private set; }
    public event Action<int> OnScoreChanged;

    public void ChangeScore(int value)
    {
        CurrentScore += CurrentScore + value >= 0 ? value : 0;
        OnScoreChanged?.Invoke(CurrentScore);
    }
}
