using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroupController : MonoBehaviour
{
    private Wall[] walls;

    private void Start()
    {
        walls = GetComponentsInChildren<Wall>();
    }
    public void DisableChildCubes()
    {
        foreach (var wall in walls)
        {
            wall.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
