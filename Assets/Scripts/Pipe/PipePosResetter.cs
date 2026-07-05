using NUnit.Framework.Constraints;
using UnityEngine;

public class PipePosResetter : MonoBehaviour
{
    private PipeRandomizer m_pipeRandomizer;
    private Vector3 m_initialPosition;

    void Start()
    {
        m_initialPosition = new Vector3(12,-6,0);
        m_pipeRandomizer = GetComponent<PipeRandomizer>();
    }

    private void Update()
    {
        RepositionPipe();
    }

    private void RepositionPipe()
    {
        if (transform.position.x < -12)
        {
            transform.position = m_initialPosition;
            GameData.IncreaseDifficulty();
            m_pipeRandomizer.RandomizeHeight();
        }
    }
}
