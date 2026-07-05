using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowDifficultyInText : MonoBehaviour
{
    [SerializeField] private DifficultyType m_difficultyType = DifficultyType.Speed;
    private TextMeshProUGUI m_TextMeshPro;

    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ShowCurrentDifficulty();
    }

    private void ShowCurrentDifficulty()
    {
        switch (m_difficultyType)
        {
            case DifficultyType.Speed:
                m_TextMeshPro.text = GameData.SpeedDifficultyMode.ToString() + "\n" +
                                     GameData.SpeedDifficulty.ToString("F2") + ".";
                return;

            case DifficultyType.SpeedIncrease:
                m_TextMeshPro.text = GameData.SpeedIncreaseDifficultyMode.ToString() + "\n" +
                                     GameData.SpeedIncrease.ToString("F3") + ".";
                return;

            case DifficultyType.PipesAmount:
                m_TextMeshPro.text = GameData.PipesAmountDifficultyMode.ToString() + "\n" +
                                     GameData.PipesAmount + ".";
                return;
        }
    }
}
