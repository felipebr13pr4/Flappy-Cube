using TMPro;
using UnityEngine;

public class ShowScoreInText : MonoBehaviour
{
    [SerializeField] private ScoreType m_scoreType;
    private TextMeshProUGUI m_text;

    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        ShowScore();
    }

    private void FixedUpdate()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        if (m_scoreType == ScoreType.FinalScore)
            m_text.text = "Final Score: " + GameData.FinalScore.ToString();

        if (m_scoreType == ScoreType.PipesPassed)
            m_text.text = "Pipes Passed: " + GameData.FinalPipesPassed.ToString();

        if (m_scoreType == ScoreType.HighScore)
            m_text.text = "High Score: " + GameData.HighScore.ToString();
    }
}
