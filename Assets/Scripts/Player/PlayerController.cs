using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject stickman;
    [SerializeField] private CubeHolderManager cubeHolderManager;
    private Animator stickmanAnimator;
    private float cubeHeight;

    private void Start()
    {
        stickmanAnimator = stickman.GetComponent<Animator>();
        cubeHeight = cubeHolderManager.GetComponentInChildren<BoxCollider>().size.y;
    }

    private void OnEnable()
    {
        CubeHolderManager.OnAddNewCube += UpdateStickmanHeight;
    }

    private void OnDisable()
    {
        CubeHolderManager.OnAddNewCube -= UpdateStickmanHeight;
    }

    private void UpdateStickmanHeight()
    {
        stickman.transform.position += new Vector3(0f, transform.position.y + cubeHeight, 0f);
        stickmanAnimator.SetTrigger("Jump");
    }
}
