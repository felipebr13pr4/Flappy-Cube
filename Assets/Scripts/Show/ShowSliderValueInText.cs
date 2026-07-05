using System;
using TMPro;
using UnityEngine;

public class ShowSliderValueInText : MonoBehaviour
{
    [SerializeField] private SliderType m_sliderType;
    private TextMeshProUGUI m_TextMeshPro;

    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        float value = m_sliderType switch
        {
            SliderType.Speed => GameData.m_speedCustomDifficulty,
            SliderType.SpeedIncrease => GameData.m_speedIncreaseCustomDifficulty,
            SliderType.PipesAmount => GameData.PipesAmount,
            SliderType.Volume => GameData.GameVolume,
            _ => GameData.m_speedCustomDifficulty
        };
        string str = m_sliderType switch
        {
            SliderType.Speed => "F2",
            SliderType.SpeedIncrease => "F3",
            SliderType.PipesAmount => "F0",
            SliderType.Volume => "F2",
            _ => "F2"
        };
        m_TextMeshPro.text = value.ToString(str);
    }
}
