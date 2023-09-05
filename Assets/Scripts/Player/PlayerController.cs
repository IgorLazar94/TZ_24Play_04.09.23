using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject stickman;
    [SerializeField] private CubeHolderManager cubeHolderManager;
    [SerializeField] private CapsuleCollider[] ragdollCapsuleColliders;
    [SerializeField] private BoxCollider[] ragdollBoxColliders;
    [SerializeField] private CapsuleCollider mainCapsule;
    [SerializeField] private Rigidbody mainRigidbody;
    private Rigidbody[] ragdollRigidbodies;
    private float cubeHeight;
    private Animator stickmanAnimator;
    private float pushForceValue = 25f;

    private void Start()
    {
        stickmanAnimator = stickman.GetComponent<Animator>();
        ragdollRigidbodies = stickmanAnimator.GetComponentsInChildren<Rigidbody>();
        cubeHeight = cubeHolderManager.GetComponentInChildren<BoxCollider>().size.y;
    }

    private void OnEnable()
    {
        CubeHolderManager.OnAddNewCube += UpdateStickmanHeight;
        GameManager.OnLosingTheGame += EnableRagdoll;
    }

    private void OnDisable()
    {
        CubeHolderManager.OnAddNewCube -= UpdateStickmanHeight;
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
}
