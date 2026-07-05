using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SafetyNet : MonoBehaviour
{
    public static event Action OnSafetyNetOff;

    void Start()
    {
        GameData.PauseGame();
    }

    void Update()
    {
        // Prevents the player from falling down until he has done one jump,
        // preventing death without inputs. And also acts as a tutorial.
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameData.UnPauseGame();
            OnSafetyNetOff?.Invoke();
            Destroy(gameObject);
        }
    }
}
