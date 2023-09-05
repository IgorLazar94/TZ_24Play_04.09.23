using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Wall : MonoBehaviour
{
    public static Action OnCrossedTheWall;
    private WallGroupController wallGroup;
    private BoxCollider wallCollider;
    private bool isGameEnded;

    private void OnEnable()
    {
        GameManager.OnLosingTheGame += SetIsGameEnded;
    }

    private void OnDisable()
    {
        GameManager.OnLosingTheGame -= SetIsGameEnded;
    }

    private void Start()
    {
        wallGroup = transform.parent.GetComponent<WallGroupController>();
        wallCollider = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagList.CubePartHolder))
        {
            collision.gameObject.GetComponent<CubePartHolder>().RemoveCubeFromHolder();
            OnCrossedTheWall.Invoke();
            if (!isGameEnded)
            {
                wallCollider.enabled = false;
                enabled = false;
            }
            wallGroup.DisableChildCubes();
        }
    }

    private void SetIsGameEnded()
    {
        isGameEnded = true;
    }
}
