using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
        }
    }
}
