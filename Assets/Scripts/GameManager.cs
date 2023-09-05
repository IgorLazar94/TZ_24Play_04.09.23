using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action OnLosingTheGame;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        OnLosingTheGame += GameLose;
    }

    private void OnDisable()
    {
        OnLosingTheGame -= GameLose;
    }

    private void GameLose()
    {
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
