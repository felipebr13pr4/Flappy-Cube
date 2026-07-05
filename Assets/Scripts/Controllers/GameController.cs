using NUnit.Framework;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        GameData.StartedApplication();

        GameData.SubscribeToEvents();
    }

    private void OnDisable()
    {
        GameData.UnSubscribeToEvents();
    }
}