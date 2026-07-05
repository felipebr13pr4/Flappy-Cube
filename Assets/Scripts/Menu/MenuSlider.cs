using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MenuSlider : MonoBehaviour
{
    [SerializeField] private SliderType m_sliderType = SliderType.Speed;
    private Slider m_sliderComponent;
    public static event Action<SliderType, float> OnSliderChangedByType;
    public static event Action OnSliderChanged;

    private void Awake()
    {
        m_sliderComponent = GetComponent<Slider>();
        SliderInitialValue();
    }

    private void OnEnable()
    {
        m_sliderComponent.onValueChanged.AddListener(SliderChanged);
    }

    private void OnDisable()
    {
        m_sliderComponent.onValueChanged.RemoveListener(SliderChanged);
    }

    private void SliderChanged(float value)
    {
        OnSliderChangedByType?.Invoke(m_sliderType, value);
        OnSliderChanged?.Invoke();
    }

    private void SliderInitialValue()
    {
        m_sliderComponent.value =
            m_sliderType == SliderType.Speed ? GameData.m_speedCustomDifficulty :
            m_sliderType == SliderType.SpeedIncrease ? GameData.m_speedIncreaseCustomDifficulty :
            m_sliderType == SliderType.PipesAmount ? GameData.m_pipesAmountCustomDifficulty :
            GameData.GameVolume;
    }
}