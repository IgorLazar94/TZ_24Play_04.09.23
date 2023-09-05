using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolderManager : MonoBehaviour
{
    public static Action OnAddNewCube;
    public GameObject cubePrefab;
    private List<CubePartHolder> childCubesList = new List<CubePartHolder>();

    private void Start()
    {
        CubePartHolder firstCube = GetComponentInChildren<CubePartHolder>();
        firstCube.SetHolderManager(this);
        childCubesList.Add(firstCube);
        FindUpperCube();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagList.PickableCube))
        {
            AddCubeToHolder();
            Destroy(other.gameObject);
        }
    }

    private void AddCubeToHolder()
    {
        OnAddNewCube?.Invoke();
        var newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity, transform);
        var childCubeScript = newCube.GetComponent<CubePartHolder>();
        childCubeScript.SetHolderManager(this);
        childCubesList.Add(childCubeScript);
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y + (childCubesList.Count - 1f), transform.position.z);
        FindUpperCube();
    }

    public void DecreaseCubeCounter(CubePartHolder cubePartHolder)
    {
        childCubesList.Remove(cubePartHolder);
    }

    public void FindUpperCube()
    {
        foreach (var cube in childCubesList)
        {
            cube.isUpperCube = false;
        }
        var upperCube = transform.GetChild(transform.childCount - 1);
        upperCube.GetComponent<CubePartHolder>().isUpperCube = true;
    }
}
