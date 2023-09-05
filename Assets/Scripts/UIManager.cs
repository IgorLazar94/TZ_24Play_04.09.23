using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject HUDPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        ActivatePanel(startPanel, true);
    }

    private void ActivatePanel(GameObject panel, bool isActive)
    {
        panel.SetActive(isActive);
    }

    public void DeactivateStartPanel()
    {
        ActivatePanel(startPanel, false);
    }

    public void ActivateLosePanel()
    {
        ActivatePanel(losePanel, true);
    }

    public void StartNewGame()
    {
        GameManager.OnStartTheGame.Invoke();
    }

    public void RestartThisLevel()
    {
        gameManager.RestartLevel();
    }
}
