using UnityEngine;

public class PartTrack : MonoBehaviour
{
    private MainTrackController mainTrackController;

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
