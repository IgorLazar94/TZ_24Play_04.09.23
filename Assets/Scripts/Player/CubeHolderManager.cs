using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolderManager : MonoBehaviour
{
    public static Action OnAddNewCube;
    public GameObject cubePrefab;
    private int cubeCounter = 1;

    private void Start()
    {
        GetComponentInChildren<CubePartHolder>().SetHolderManager(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagList.PickableCube))
        {
            AddCubeToHolder();
            cubeCounter++;
            Destroy(other.gameObject);
        }
    }

    private void AddCubeToHolder()
    {
        OnAddNewCube?.Invoke();
        var newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity, transform);
        newCube.GetComponent<CubePartHolder>().SetHolderManager(this);
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y + cubeCounter, transform.position.z);
    }

    public void DecreaseCubeCounter()
    {
        cubeCounter--;
    }
}
