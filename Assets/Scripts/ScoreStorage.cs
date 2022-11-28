using System;

public class ScoreStorage : SingletonObject<ScoreStorage>
{
    public int CurrentScore { get; private set; }
    public event Action<int> OnScoreChanged;

    public void ChangeScore(int value)
    {
        CurrentScore += CurrentScore + value >= 0 ? value : 0;
        OnScoreChanged?.Invoke(CurrentScore);
    }
}
