using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePartHolder : MonoBehaviour
{
    public bool isUpperCube { private get; set; }
    private CubeHolderManager cubeHolderManager;
    
    public void SetHolderManager(CubeHolderManager _cubeHolderManager)
    {
        this.cubeHolderManager = _cubeHolderManager;
    }

    public void RemoveCubeFromHolder()
    {
        CheckLooseCondition();
        gameObject.transform.parent = null;
        cubeHolderManager.DecreaseCubeCounter();
    }

    private void CheckLooseCondition()
    {
        if (isUpperCube)
        {
            GameManager.OnLosingTheGame?.Invoke();
            //this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
