using Unity.VisualScripting;
using UnityEngine;

public class PipeRandomizer : MonoBehaviour
{
    void Start()
    {
        RandomizeHeight();
    }

    public void RandomizeHeight()
    {
        float randomPos = Random.Range(-2f, 2f);
        transform.position += new Vector3(0, randomPos, 0);
    }
}
