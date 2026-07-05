using System;
using UnityEngine;

public class PipeScore : MonoBehaviour
{
    public static event Action<int> OnScoreIncrease;
    private int m_scoreIncrease = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnScoreIncrease?.Invoke(m_scoreIncrease);
    }
}
