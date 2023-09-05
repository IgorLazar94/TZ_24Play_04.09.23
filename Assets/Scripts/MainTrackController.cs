using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class MainTrackController : MonoBehaviour
{
    [SerializeField] private GameObject[] partTrackPrefabs;
    private List<PartTrack> listOfTracks = new List<PartTrack>();
    private float trackLength;
    private float correctTrackHeight;
    private int counter;
    private float timeToRaiseTrack = 0.75f;
    private float distanceToRaiseTrack = 30f;

    private void Start()
    {
        AdReadyPartOfTracks();
        trackLength = listOfTracks[0].transform.localScale.z;
        correctTrackHeight = listOfTracks[0].transform.localPosition.y;
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
        int randomNumber = Random.Range(0, partTrackPrefabs.Length);
        var newTrack = Instantiate(partTrackPrefabs[randomNumber], transform.position, Quaternion.identity, transform);
        newTrack.GetComponent<PartTrack>().SetParentTrackController(this);
        newTrack.transform.position = new Vector3(newTrack.transform.position.x, 
                                                  newTrack.transform.position.y - distanceToRaiseTrack, 
                                                  newTrack.transform.position.z + (counter * trackLength));
        newTrack.transform.DOMoveY(correctTrackHeight, timeToRaiseTrack);
        counter++;
    }
}
