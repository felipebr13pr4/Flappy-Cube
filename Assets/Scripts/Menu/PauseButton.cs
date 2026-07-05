using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseWindow;
    [SerializeField] private Button m_pauseButton;


    private void OnEnable()
    {
        m_pauseButton.onClick.AddListener(TogglePauseWindow);
    }

    private void OnDisable()
    {
        m_pauseButton.onClick.RemoveListener(TogglePauseWindow);
    }

    public void TogglePauseWindow()
    {
        if (!GameData.IsGamePaused)
        {
            m_pauseWindow.SetActive(true);
            GameData.PauseGame();
        }
        else
        {
            m_pauseWindow.SetActive(false);
            GameData.UnPauseGame();
        }
    }
}
