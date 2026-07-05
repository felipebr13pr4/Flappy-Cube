using System;
using UnityEngine;

[RequireComponent(typeof(GameSceneController))]
public class ScoreController : MonoBehaviour
{
    public static event Action<int, int, int> OnFinalScores;
    private int m_totalPipesPassed;
    private float m_totalScore;

    private void OnEnable()
    {
        PipeScore.OnScoreIncrease += AddScore;
        Bird.OnBirdDeath += CalculateScore;
    }

    private void OnDisable()
    {
        PipeScore.OnScoreIncrease -= AddScore;
        Bird.OnBirdDeath -= CalculateScore;
    }

    private void AddScore(int value)
    {
        m_totalPipesPassed += value;
    }

    private void CalculateScore()
    {
        m_totalScore = m_totalPipesPassed;
        float scoreMultiply = CalculateScoreMultiplier();
        m_totalScore *= scoreMultiply;
        int m_intTotalScore = Mathf.RoundToInt(m_totalScore);
        int highScore = m_intTotalScore > GameData.HighScore ? m_intTotalScore : GameData.HighScore;
        OnFinalScores?.Invoke(m_intTotalScore, m_totalPipesPassed, highScore);
    }

    public float CalculateScoreMultiplier()
    {
        float score = 1;

        score +=
            GameData.PipesAmountDifficultyMode == Difficulties.Easy ? 3 * 3 :
            GameData.PipesAmountDifficultyMode == Difficulties.Medium ? 4 * 4 :
            GameData.PipesAmountDifficultyMode == Difficulties.Hard ? 5 * 5 : DecideScoreByCustomDifficulty();

        score *=
            GameData.SpeedDifficultyMode == Difficulties.Easy ? 0.75f*2 :
            GameData.SpeedDifficultyMode == Difficulties.Medium ? 1f*2 :
            GameData.SpeedDifficultyMode == Difficulties.Hard ? 1.5f*2 : GameData.m_speedCustomDifficulty*2;

        score *=
            GameData.SpeedIncreaseDifficultyMode == Difficulties.Easy ? (0.025f*5)+1 :
            GameData.SpeedIncreaseDifficultyMode == Difficulties.Medium ? (0.05f*5)+1 :
            GameData.SpeedIncreaseDifficultyMode == Difficulties.Hard ? (0.1f*5)+1 : (GameData.m_speedIncreaseCustomDifficulty*5)+1;

        return score;
    }

    private float DecideScoreByCustomDifficulty()
    {
        float value = GameData.m_pipesAmountCustomDifficulty switch
        {
            1 => 1,
            2 => 4,
            3 => 9,
            4 => 16,
            5 => 25,
            6 => 35,
            7 => 50,
            _ => 1
        };
        return value;
    }
}
