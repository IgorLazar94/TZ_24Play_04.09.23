using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolderManager : MonoBehaviour
{
    public static Action OnAddNewCube;
    public GameObject cubePrefab;
    private int cubeCounter = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickableCube"))
        {
            Debug.Log("Cube holder find pickup");
            AddCubeToHolder();
            cubeCounter++;
            Destroy(other.gameObject);
        }
    }

    private void AddCubeToHolder()
    {
        OnAddNewCube?.Invoke();
        var newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity, transform);
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y + cubeCounter, transform.position.z);
    }
}
