using UnityEngine;

public class DisableOnGameOver : MonoBehaviour
{
    private void OnEnable()
    {
        Bird.OnBirdDeath += Hide;
    }

    private void OnDisable()
    {
        Bird.OnBirdDeath -= Hide;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
