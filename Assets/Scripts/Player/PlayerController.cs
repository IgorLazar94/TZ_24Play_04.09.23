using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject stickman;
    [SerializeField] private CubeHolderManager cubeHolderManager;
    [SerializeField] private CapsuleCollider[] ragdollCapsuleColliders;
    [SerializeField] private BoxCollider[] ragdollBoxColliders;
    [SerializeField] private CapsuleCollider mainCapsule;
    [SerializeField] private Rigidbody mainRigidbody;
    [SerializeField] private Animation scoresTextAnimation;
    private Rigidbody[] ragdollRigidbodies;
    private float cubeHeight;
    private Animator stickmanAnimator;
    private float pushForceValue;
    private TextMeshProUGUI scoresText;

    private void Start()
    {
        pushForceValue = GameSettings.Instance.GetPlayerPushForceValue();
        scoresText = GetComponentInChildren<TextMeshProUGUI>();
        scoresText.gameObject.SetActive(false);
        stickmanAnimator = stickman.GetComponent<Animator>();
        ragdollRigidbodies = stickmanAnimator.GetComponentsInChildren<Rigidbody>();
        cubeHeight = cubeHolderManager.GetComponentInChildren<BoxCollider>().size.y + 1f;
    }

    private void OnEnable()
    {
        CubeHolderManager.OnAddNewCube += UpdateStickmanHeight;
        CubeHolderManager.OnAddNewCube += UpdateScoresText;
        GameManager.OnLosingTheGame += EnableRagdoll;
    }

    private void OnDisable()
    {
        CubeHolderManager.OnAddNewCube -= UpdateStickmanHeight;
        CubeHolderManager.OnAddNewCube -= UpdateScoresText;
        GameManager.OnLosingTheGame -= EnableRagdoll;
    }

    private void UpdateStickmanHeight()
    {
        stickman.transform.position += new Vector3(0f, transform.position.y + cubeHeight, 0f);
        stickmanAnimator.SetTrigger("Jump");
    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.AddForce(Vector3.forward * pushForceValue, ForceMode.Impulse);
        }
        foreach (var ragdollBoxCollider in ragdollBoxColliders)
        {
            ragdollBoxCollider.enabled = true;
        }
        foreach (var ragdollCapsuleCollider in ragdollCapsuleColliders)
        {
            ragdollCapsuleCollider.enabled = true;
        }
        mainCapsule.enabled = false;
        mainRigidbody.isKinematic = true;
        stickmanAnimator.enabled = false;
    }

    private void UpdateScoresText()
    {
        scoresTextAnimation.gameObject.SetActive(true);
        scoresTextAnimation.Play();
        Invoke(nameof(DisableScoresTextAnimation), scoresTextAnimation.clip.length);
    }

    private void DisableScoresText(Vector2 initialPosition, RectTransform scoresRectTransform)
    {
        scoresRectTransform.DOAnchorPosY(initialPosition.y, 0f);
        scoresText.gameObject.SetActive(false);
    }

    private void DisableScoresTextAnimation()
    {
        scoresTextAnimation.gameObject.SetActive(false);
    }
}
