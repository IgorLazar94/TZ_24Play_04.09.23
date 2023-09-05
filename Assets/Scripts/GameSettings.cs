using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Header("Player Settings")]
    [SerializeField] private float playerForwardSpeed;
    [SerializeField] private float playerOffsetSpeed;
    [SerializeField] private float playerPushForceValue;
    [Header("Track Settings")]
    [SerializeField] private float timeToRaiseTrack;
    [SerializeField] private float distanceToRaiseTrack;



    public float GetPlayerForwardSpeed()
    {
        return playerForwardSpeed;
    }
    public float GetPlayerOffsetSpeed()
    {
        return playerOffsetSpeed;
    }
    public float GetPlayerPushForceValue()
    {
        return playerPushForceValue;
    }
    public float GetTimeToRaiseTrack()
    {
        return timeToRaiseTrack;
    }
    public float GetDistanceToRaiseTrack()
    {
        return distanceToRaiseTrack;
    }

}
