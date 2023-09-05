using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainTrackController : MonoBehaviour
{
    [SerializeField] private GameObject partTrackPrefab1/*, partTrackPrefab2, partTrackPrefab3*/;
    private List<PartTrack> listOfTracks = new List<PartTrack>();
    private float trackLength;
    private float trackHeight;
    private int counter;

    private void Start()
    {
        AdReadyPartOfTracks();
        trackLength = listOfTracks[0].transform.localScale.z;
        trackHeight = listOfTracks[0].transform.localPosition.y;
    }

    private void AdReadyPartOfTracks()
    {
        var tracks = GetComponentsInChildren<PartTrack>();
        foreach (var track in tracks)
        {
            listOfTracks.Add(track);
            track.SetParentTrackController(this);
        }
        counter = listOfTracks.Count;
    }

    public void InitialNewPartOfTrack()
    {
        var newTrack = Instantiate(partTrackPrefab1, transform.position, Quaternion.identity, transform);
        newTrack.transform.position = new Vector3(newTrack.transform.position.x, 
                                                  newTrack.transform.position.y + trackHeight, 
                                                  newTrack.transform.position.z + (counter * trackLength));
        counter++;
    }
}
