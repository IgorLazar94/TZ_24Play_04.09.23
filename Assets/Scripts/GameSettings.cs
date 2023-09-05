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
    [SerializeField] private float playerOffsetSpeedPC;
    [SerializeField] private float playerOffsetSpeedAndroid;
    [SerializeField] private float playerPushForceValue;
    [Header("Track Settings")]
    [SerializeField] private float timeToRaiseTrack;
    [SerializeField] private float distanceToRaiseTrack;
    [Header("Camera Shake")]
    [SerializeField] private float cameraShakeDuration;
    [SerializeField] private float cameraShakeMagnitude;

    public float GetPlayerForwardSpeed()
    {
        return playerForwardSpeed;
    }
    public float GetPlayerOffsetSpeedPC()
    {
        return playerOffsetSpeedPC;
    }
    public float GetPlayerOffsetSpeedAndroid()
    {
        return playerOffsetSpeedAndroid;
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
    public float GetCameraShakeDuration()
    {
        return cameraShakeDuration;
    }
    public float GetCameraShakeMagnitude()
    {
        return cameraShakeMagnitude;
    }
}
