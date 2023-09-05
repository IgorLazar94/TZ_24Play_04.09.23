using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Wall : MonoBehaviour
{
    public static Action OnCrossedTheWall;
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
        }
    }

    private void SetIsGameEnded()
    {
        isGameEnded = true;
    }
}
