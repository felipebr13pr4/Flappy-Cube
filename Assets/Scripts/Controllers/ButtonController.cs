using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(GameSceneController))]
public class ButtonController : MonoBehaviour
{
    private GameSceneController m_gameSceneController;
    public static event Action OnDifficultyButtonClicked;

    private void Start()
    {
        m_gameSceneController = GetComponent<GameSceneController>();
    }

    private void OnEnable()
    {
        MenuButton.OnButtonTypeClicked += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuButton.OnButtonTypeClicked -= ExecuteAction;
    }

    private void ExecuteAction(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.Start:
                m_gameSceneController.LoadScene(SceneType.Game);
                return;

            case ButtonType.Retry:
                m_gameSceneController.ReloadScene();
                return;

            case ButtonType.MainMenu:
                m_gameSceneController.LoadScene(SceneType.Menu);
                return;

            case ButtonType.Quit:
                PlayerPrefs.SetFloat("Volume", GameData.GameVolume);
                PlayerPrefs.SetInt("HighScore", GameData.HighScore);
                PlayerPrefs.Save();
                Application.Quit();
                return;


            case ButtonType.SpeedEasy:
            case ButtonType.SpeedMedium:
            case ButtonType.SpeedHard:
            case ButtonType.SpeedCustom:
                HandleSpeedDifficulty(type);
                return;


            case ButtonType.SpeedIncreaseEasy:
            case ButtonType.SpeedIncreaseMedium:
            case ButtonType.SpeedIncreaseHard:
            case ButtonType.SpeedIncreaseCustom:
                HandleSpeedIncreaseDifficulty(type);
                return;


            case ButtonType.PipeAmountEasy:
            case ButtonType.PipeAmountMedium:
            case ButtonType.PipeAmountHard:
            case ButtonType.PipeAmountCustom:
                HandlePipeAmountDifficultyMode(type);
                return;
        }
    }

    private void HandleSpeedDifficulty(ButtonType type)
    {
        Difficulties diff =
            type == ButtonType.SpeedEasy ? Difficulties.Easy :
            type == ButtonType.SpeedMedium ? Difficulties.Medium :
            type == ButtonType.SpeedHard ? Difficulties.Hard : Difficulties.Custom;

        GameData.SetSpeedDifficultyMode(diff);
     
        OnDifficultyButtonClicked?.Invoke();
    }

    private void HandleSpeedIncreaseDifficulty(ButtonType type)
    {
        Difficulties diff =
            type == ButtonType.SpeedIncreaseEasy ? Difficulties.Easy :
            type == ButtonType.SpeedIncreaseMedium ? Difficulties.Medium :
            type == ButtonType.SpeedIncreaseHard ? Difficulties.Hard : Difficulties.Custom;

        GameData.SetSpeedIncreaseDifficultyMode(diff);
     
        OnDifficultyButtonClicked?.Invoke();
    }

    private void HandlePipeAmountDifficultyMode(ButtonType type)
    {
        Difficulties diff =
            type == ButtonType.PipeAmountEasy ? Difficulties.Easy :
            type == ButtonType.PipeAmountMedium ? Difficulties.Medium :
            type == ButtonType.PipeAmountHard ? Difficulties.Hard : Difficulties.Custom;

        GameData.SetPipeAmountDifficultyMode(diff);

        OnDifficultyButtonClicked?.Invoke();
    }
}
