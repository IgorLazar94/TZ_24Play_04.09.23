using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            uIManager.DeactivateStartPanel();
            Time.timeScale = 1;
        }
    }

    private void GameLose()
    {
        uIManager.ActivateLosePanel();
    }
}
