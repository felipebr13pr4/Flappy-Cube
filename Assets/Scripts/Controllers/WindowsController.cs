using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

[RequireComponent(typeof(GameSceneController))]
public class WindowsController : MonoBehaviour
{
    [SerializeField] GameObject m_pauseWindow;
    [SerializeField] GameObject m_deathWindow;
    [SerializeField] GameObject m_tutorialPrompt;
    [SerializeField] GameObject m_pauseButton;

    private void Start()
    {
        m_tutorialPrompt.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        Bird.OnBirdDeath += OpenDeathWindow;
        SafetyNet.OnSafetyNetOff += TutorialOff;
    }

    private void OnDisable()
    {
        Bird.OnBirdDeath -= OpenDeathWindow;
        SafetyNet.OnSafetyNetOff -= TutorialOff;
    }

    public void OpenDeathWindow()
    {
        m_deathWindow.SetActive(true);
        m_pauseWindow.SetActive(false);
    }

    private void TutorialOff()
    {
        m_tutorialPrompt.SetActive(false);
        m_pauseButton.SetActive(true);
    }
}
