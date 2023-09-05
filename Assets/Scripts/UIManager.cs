using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Image handSprite;
    private RectTransform startHandSpriteTransform;
    public float startPosXHandSprite = -190f;
    public float endPosXHandSprite = 210f;
    public float moveDurationHandSprite = 1.5f;

    private void Awake()
    {
        ActivatePanel(startPanel, true);
    }

    private void Start()
    {
        AnimateHandSprite();
    }

    private void AnimateHandSprite()
    {
        startHandSpriteTransform = handSprite.GetComponent<RectTransform>();
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(startHandSpriteTransform.DOAnchorPosX(endPosXHandSprite, moveDurationHandSprite));
        moveSequence.Append(startHandSpriteTransform.DOAnchorPosX(startPosXHandSprite, moveDurationHandSprite));
        moveSequence.SetLoops(-1);
        moveSequence.SetEase(Ease.OutSine);
        moveSequence.Play();
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
