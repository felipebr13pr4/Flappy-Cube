using UnityEngine;
using UnityEngine.UI;

public class ShowCustomDifficultySliders : MonoBehaviour
{
    [SerializeField] private GameObject speedSlider;
    [SerializeField] private GameObject speedIncreaseSlider;
    [SerializeField] private GameObject pipeAmountSlider;
    private Image customDifficultyWindow;

    private void Start()
    {
        customDifficultyWindow = GetComponentInParent<Image>();
    }

    private void OnEnable()
    {
        ButtonController.OnDifficultyButtonClicked += ToggleSliders;
    }

    private void OnDisable()
    {
        ButtonController.OnDifficultyButtonClicked -= ToggleSliders;
    }

    private void ToggleSliders()
    {
        if (GameData.SpeedDifficultyMode != Difficulties.Custom &&
            GameData.SpeedIncreaseDifficultyMode != Difficulties.Custom &&
            GameData.PipesAmountDifficultyMode != Difficulties.Custom) customDifficultyWindow.gameObject.SetActive(false);

        if (GameData.SpeedDifficultyMode == Difficulties.Custom)
            speedSlider.SetActive(true);
        else speedSlider.SetActive(false);

        if (GameData.SpeedIncreaseDifficultyMode == Difficulties.Custom)
            speedIncreaseSlider.SetActive(true);
        else speedIncreaseSlider.SetActive(false);

        if (GameData.PipesAmountDifficultyMode == Difficulties.Custom)
            pipeAmountSlider.SetActive(true);
        else pipeAmountSlider.SetActive(false);
    }
}
