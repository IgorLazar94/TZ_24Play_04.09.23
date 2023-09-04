using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePartHolder : MonoBehaviour
{
    private CubeHolderManager cubeHolderManager;
    
    public void SetHolderManager(CubeHolderManager _cubeHolderManager)
    {
        this.cubeHolderManager = _cubeHolderManager;
    }

    public void RemoveCubeFromHolder()
    {
        gameObject.transform.parent = null;
        cubeHolderManager.DecreaseCubeCounter();
    }
}
