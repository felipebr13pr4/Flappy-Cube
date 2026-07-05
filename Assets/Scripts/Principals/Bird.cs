using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;
    private SpriteRenderer m_childSprite;
    public float flapForce { get; } = 10;
    public static event Action OnBirdDeath;
    public static event Action<AudioType> OnAudio;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_childSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            FlapUp();
        }

        RotateOnJump();

        if (transform.position.y >= 4.5f | transform.position.y <= -4.5f)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Die();
        }
    }

    public void FlapUp()
    {
        if (GameData.IsGamePaused) return;
        m_rigidBody.linearVelocity = Vector2.up * flapForce;
        OnAudio?.Invoke(AudioType.Jump);
    }

    private void Die()
    {
        OnBirdDeath?.Invoke();
        OnAudio?.Invoke(AudioType.Death);
        Destroy(gameObject);
        Time.timeScale = 0;
    }

    private void RotateOnJump()
    {
        float rotation = m_rigidBody.linearVelocityY;
        rotation = Mathf.Clamp(rotation, -45f, 45f);
        m_childSprite.transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
