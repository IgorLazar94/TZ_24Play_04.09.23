using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTrack : MonoBehaviour
{
    private MainTrackController mainTrackController;
    //private bool isCorrectHeightPosition = false;

    //private void FixedUpdate()
    //{
    //    if (!isCorrectHeightPosition)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //    }
    //}



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagList.Player))
        {
            CreatePartOfTrack();
        }
    }

    public void SetParentTrackController(MainTrackController _mainTrackController)
    {
        mainTrackController = _mainTrackController;
    }

    private void CreatePartOfTrack()
    {
        mainTrackController.InitialNewPartOfTrack();
    }
}
