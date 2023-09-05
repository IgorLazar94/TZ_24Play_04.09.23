using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePartHolder : MonoBehaviour
{
    public bool isUpperCube { private get; set; }
    private CubeHolderManager cubeHolderManager;
    private float timeToDestroyLostCube = 3f;
    
    public void SetHolderManager(CubeHolderManager _cubeHolderManager)
    {
        this.cubeHolderManager = _cubeHolderManager;
    }

    public void RemoveCubeFromHolder()
    {
        CheckLooseCondition();
        gameObject.transform.parent = null;
        StartCoroutine(DestroyLostCube());
        cubeHolderManager.ClearCubeFromList(this);
    }

    private IEnumerator DestroyLostCube()
    {
        yield return new WaitForSeconds(timeToDestroyLostCube);
        Destroy(this.gameObject);
    }

    private void CheckLooseCondition()
    {
        if (isUpperCube)
        {
            GameManager.OnLosingTheGame?.Invoke();
        }
    }
}
