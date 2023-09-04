using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider wallCollider;

    private void Start()
    {
        wallCollider = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagList.CubePartHolder))
        {
            wallCollider.enabled = false;
            collision.gameObject.GetComponent<CubePartHolder>().RemoveCubeFromHolder();
            enabled = false;
        }
    }
}
