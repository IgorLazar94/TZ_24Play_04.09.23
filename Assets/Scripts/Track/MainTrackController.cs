using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainTrackController : MonoBehaviour
{
    [SerializeField] private GameObject[] partTrackPrefabs;
    private List<PartTrack> listOfActiveTracks = new List<PartTrack>();
    private float trackLength;
    private float correctTrackHeight;
    private float timeToRaiseTrack;
    private float distanceToRaiseTrack;
    private int counter;

    private void Start()
    {
        timeToRaiseTrack = GameSettings.Instance.GetTimeToRaiseTrack();
        distanceToRaiseTrack = GameSettings.Instance.GetDistanceToRaiseTrack();
        AdReadyPartOfTracks();
        GetTrackValues();
    }

    private void GetTrackValues()
    {
        trackLength = listOfActiveTracks[0].transform.localScale.z;
        correctTrackHeight = listOfActiveTracks[0].transform.localPosition.y;
    }

    private void AdReadyPartOfTracks()
    {
        var tracks = GetComponentsInChildren<PartTrack>();
        foreach (var track in tracks)
        {
            listOfActiveTracks.Add(track);
            track.SetParentTrackController(this);
        }
        counter = listOfActiveTracks.Count;
    }

    public void InitialNewPartOfTrack()
    {
        int randomNumber = Random.Range(0, partTrackPrefabs.Length);
        var newTrack = Instantiate(partTrackPrefabs[randomNumber], transform.position, Quaternion.identity, transform);
        PartTrack newTrackScript = newTrack.GetComponent<PartTrack>();
        newTrackScript.SetParentTrackController(this);
        listOfActiveTracks.Add(newTrackScript);
        newTrack.transform.position = new Vector3(newTrack.transform.position.x, 
                                                  newTrack.transform.position.y - distanceToRaiseTrack, 
                                                  newTrack.transform.position.z + (counter * trackLength));
        newTrack.transform.DOMoveY(correctTrackHeight, timeToRaiseTrack);
        counter++;
        if (listOfActiveTracks.Count >= 5)
        {
            ClearUnnecessaryTracks();
        }
    }

    private void ClearUnnecessaryTracks()
    {
        Destroy(listOfActiveTracks[0].gameObject);
        listOfActiveTracks.RemoveAt(0);
    }
}
