using UnityEngine;

public class DebuggerTesting : MonoBehaviour
{
    // [SerializeField] float m_timer = 250;
    // [SerializeField] bool m_difficultyPrints;

    private void Start()
    {
        print(GameData.m_speedCustomDifficulty);
        print(GameData.m_speedIncreaseCustomDifficulty);
        print(GameData.m_pipesAmountCustomDifficulty);
        print(GameData.SpeedDifficultyMode);
        print(GameData.SpeedIncreaseDifficultyMode);
        print(GameData.PipesAmountDifficultyMode);
    }

    void Update()
    {
        /*m_timer--;
        if (m_timer <= 0)
        {
            checkDifficultyPrints();
            m_timer = 250;
        }*/
    }


    /*private void checkDifficultyPrints()
    {
        if (!m_difficultyPrints) return;
        print(GameData.SpeedDifficulty);
    }*/
}
