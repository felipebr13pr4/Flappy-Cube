using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameSceneController))]
public class GameSceneController : MonoBehaviour
{

    public void LoadScene(SceneType type)
    {
        string sceneToLoad = type switch
        {
            SceneType.Game => "MainGame",
            SceneType.Menu => "MainMenu",
            _ => "MainMenu",
        };

        ResetStates();

        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene()
    {
        ResetStates();

        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void ResetStates()
    {
        GameData.UnPauseGame();

        GameData.GameOverOff();

        GameData.ResetDifficultys();
    }
}
