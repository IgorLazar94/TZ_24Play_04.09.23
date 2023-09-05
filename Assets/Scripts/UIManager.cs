using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Image handSprite;
    private float startPosXHandSprite = -190f;
    private float endPosXHandSprite = 210f;
    private float moveDurationHandSprite = 1.5f;
    private RectTransform startHandSpriteTransform;

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
        Sequence moveHandIconSeq = DOTween.Sequence();
        moveHandIconSeq.Append(startHandSpriteTransform.DOAnchorPosX(endPosXHandSprite, moveDurationHandSprite));
        moveHandIconSeq.Append(startHandSpriteTransform.DOAnchorPosX(startPosXHandSprite, moveDurationHandSprite));
        moveHandIconSeq.SetEase(Ease.OutSine);
        moveHandIconSeq.SetLoops(-1);
        moveHandIconSeq.Play();
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
