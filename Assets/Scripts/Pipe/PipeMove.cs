using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float m_speed = 3;

    void Update()
    {
        float spd = m_speed * GameData.SpeedDifficulty * Time.deltaTime;
        transform.position -= new Vector3(spd, 0, 0);
    }
}
