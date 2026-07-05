using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class GameData
{
    private static float m_speedDifficulty = 1;
    private static Difficulties m_speedDifficultyMode = Difficulties.Medium;

    private static float m_speedIncrease = 0.05f;
    private static Difficulties m_speedIncreaseDifficultyMode = Difficulties.Medium;

    private static int m_pipesAmount = 4;
    private static Difficulties m_pipesAmountDifficultyMode = Difficulties.Medium;

    public static float m_speedCustomDifficulty = 1;
    public static float m_speedIncreaseCustomDifficulty = 0.05f;
    public static int m_pipesAmountCustomDifficulty = 4;

    private static bool m_isGamePaused = false;

    private static float m_gameVolume = 1;
    
    private static bool m_startedApplication = false;

    public static float SpeedDifficulty
    {
        get { return m_speedDifficulty; }
        private set {
            m_speedDifficulty = Mathf.Clamp(value, 0.1f, 3f);
        }
    }
    public static float SpeedIncrease => m_speedIncrease;
    public static int PipesAmount
    {
        get { return m_pipesAmount; }
        private set
        {
            m_pipesAmount = Mathf.Clamp(value, 1, 7);
        }
    }

    public static Difficulties SpeedDifficultyMode
    {
        get { return m_speedDifficultyMode; }
    }
    public static Difficulties SpeedIncreaseDifficultyMode
    {
        get { return m_speedIncreaseDifficultyMode; }
    }
    public static Difficulties PipesAmountDifficultyMode
    {
        get { return m_pipesAmountDifficultyMode; }
    }

    public static bool IsGamePaused
    { 
        get
        {
            return m_isGamePaused;
        }
        private set
        {
            m_isGamePaused = value;
            int i = value ? 0 : 1;
            Time.timeScale = i;
        }
    }
    public static float GameVolume
    {
        get
        {
            return m_gameVolume;
        }
        set
        {
            m_gameVolume = Mathf.Clamp(value, 0, 1);
        }
    }
    public static bool IsGameOver { get; private set; }

    public static int FinalScore {  get; private set; }
    public static int FinalPipesPassed {  get; private set; }
    public static int HighScore {  get; private set; }

    public static void SubscribeToEvents()
    {
        Bird.OnBirdDeath += GameOverOn;
        Bird.OnBirdDeath += ResetDifficultys;
        ButtonController.OnDifficultyButtonClicked += ResetDifficultys;
        MenuSlider.OnSliderChanged += ResetDifficultys;
        ScoreController.OnFinalScores += UpdateScores;
    }

    public static void UnSubscribeToEvents()
    {
        Bird.OnBirdDeath -= GameOverOn;
        Bird.OnBirdDeath -= ResetDifficultys;
        ButtonController.OnDifficultyButtonClicked -= ResetDifficultys;
        MenuSlider.OnSliderChanged -= ResetDifficultys;
        ScoreController.OnFinalScores -= UpdateScores;
    }

    public static void PauseGame()
    {
        IsGamePaused = true;
    }

    public static void UnPauseGame()
    {
        IsGamePaused = false;
    }

    private static void GameOverOn()
    {
        IsGameOver = true;
    }

    public static void GameOverOff()
    {
        IsGameOver = false;
    }

    public static void ResetDifficultys()
    {
        SpeedDifficulty =
            m_speedDifficultyMode == Difficulties.Easy ? 0.75f :
            m_speedDifficultyMode == Difficulties.Medium ? 1f :
            m_speedDifficultyMode == Difficulties.Hard ? 1.5f : m_speedCustomDifficulty;

        m_speedIncrease =
            m_speedIncreaseDifficultyMode == Difficulties.Easy ? 0.025f :
            m_speedIncreaseDifficultyMode == Difficulties.Medium ? 0.05f :
            m_speedIncreaseDifficultyMode == Difficulties.Hard ? 0.1f : m_speedIncreaseCustomDifficulty;

        PipesAmount =
            m_pipesAmountDifficultyMode == Difficulties.Easy ? 3 :
            m_pipesAmountDifficultyMode == Difficulties.Medium ? 4 :
            m_pipesAmountDifficultyMode == Difficulties.Hard ? 5 : m_pipesAmountCustomDifficulty;

    }

    public static void SetSpeedDifficultyMode(Difficulties newDifficulty)
    {
        m_speedDifficultyMode = newDifficulty;
    }

    public static void SetSpeedIncreaseDifficultyMode(Difficulties newDifficulty)
    {
        m_speedIncreaseDifficultyMode = newDifficulty;
    }

    public static void SetPipeAmountDifficultyMode(Difficulties newDifficulty)
    {
        m_pipesAmountDifficultyMode = newDifficulty;
    }

    public static void IncreaseDifficulty()
    {
        SpeedDifficulty += m_speedIncrease;
    }

    private static void UpdateScores(int finalScore, int pipesPassed, int highScore)
    {
        FinalScore = finalScore;
        FinalPipesPassed = pipesPassed;
        HighScore = highScore;
    }

    public static void StartedApplication()
    {
        if (m_startedApplication) return;
        m_startedApplication = true;
        GameVolume = PlayerPrefs.GetFloat("Volume", 1);
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
