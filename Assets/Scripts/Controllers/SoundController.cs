using UnityEngine;

[RequireComponent(typeof(GameSceneController))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip m_jumpAudio;
    [SerializeField] private AudioClip m_deathAudio;
    private float m_audioVolume = 1;
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioVolume = GameData.GameVolume;
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Bird.OnAudio += PlayAudio;
    }

    private void OnDisable()
    {   
        Bird.OnAudio -= PlayAudio;
    }

    private void PlayAudio(AudioType type)
    {
        m_audioVolume = GameData.GameVolume;
        switch (type)
        {
            case AudioType.Jump: m_audioSource.PlayOneShot(m_jumpAudio, m_audioVolume); return;
            case AudioType.Death: m_audioSource.PlayOneShot(m_deathAudio, m_audioVolume); return;
        }
    }
}