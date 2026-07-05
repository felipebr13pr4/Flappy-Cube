using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_pipePrefab;
    [SerializeField] private float m_distanceBetweenPipes;
    private int m_maxPipeAmount;
    private int m_pipeCount = 0;
    private bool m_canSpawnPipe = true;
    private BoxCollider2D m_boxColliderTrigger;

    private void Start()
    {
        m_maxPipeAmount = GameData.PipesAmount;
        float pipeArea = 24;
        float readjustFix = 1.5f; // The adjustment needed for it to trigger at the right pos
        m_distanceBetweenPipes = (pipeArea / (float)m_maxPipeAmount) + readjustFix;
        m_boxColliderTrigger = GetComponentInChildren<BoxCollider2D>();
        m_boxColliderTrigger.transform.position -= new Vector3(m_distanceBetweenPipes, 0, 0);
    }

    void Update()
    {
        if (GameData.IsGamePaused || GameData.IsGameOver) return;
        if (m_pipeCount < m_maxPipeAmount & m_canSpawnPipe)
        {
            m_canSpawnPipe = false;
            Instantiate(m_pipePrefab, transform.position, transform.rotation);
            m_pipeCount++;
        }else if (m_pipeCount == m_maxPipeAmount)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_canSpawnPipe = true;
    }
}
