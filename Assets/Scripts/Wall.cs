using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
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
