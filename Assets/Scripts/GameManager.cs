using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action OnLosingTheGame;
    public static Action OnStartTheGame;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        OnStartTheGame += StartGame;
        OnLosingTheGame += GameLose;
    }

    private void OnDisable()
    {
        OnStartTheGame -= StartGame;
        OnLosingTheGame -= GameLose;
    }

    private void GameLose()
    {
        Handheld.Vibrate();
        uIManager.ActivateLosePanel();
        InputController.isReadyToMove = false;
    }

    public void StartGame()
    {
        uIManager.DeactivateStartPanel();
        InputController.isReadyToMove = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
