using TMPro;
using UnityEngine;

public class ShowScoreMultiplicationInText : MonoBehaviour
{
    [SerializeField] private ScoreController m_scoreController;
    private TextMeshProUGUI m_text;
    private float m_scoreMultiplication;

    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        m_scoreMultiplication = m_scoreController.CalculateScoreMultiplier();
        m_text.text = "Score Multiplication: " + m_scoreMultiplication.ToString("F2") + "x";
    }

    void Update()
    {
        m_scoreMultiplication = m_scoreController.CalculateScoreMultiplier();
        m_text.text = "Score Multiplication: " + m_scoreMultiplication.ToString("F2") + "x";
    }
}