using UnityEngine;

[RequireComponent(typeof(GameSceneController))]
public class SliderController : MonoBehaviour
{
    private void OnEnable()
    {
        MenuSlider.OnSliderChangedByType += ExecuteAction;
    }

    private void OnDisable()
    {
        MenuSlider.OnSliderChangedByType -= ExecuteAction;
    }

    private void ExecuteAction(SliderType type, float value)
    {
        switch (type)
        {
            case SliderType.Speed:
                GameData.m_speedCustomDifficulty = value;
                return;


            case SliderType.SpeedIncrease:
                GameData.m_speedIncreaseCustomDifficulty = value;
                return;


            case SliderType.PipesAmount:
                GameData.m_pipesAmountCustomDifficulty = (int)value;
                return;

            case SliderType.Volume:
                GameData.GameVolume = value;
                return;
        }
    }
}
