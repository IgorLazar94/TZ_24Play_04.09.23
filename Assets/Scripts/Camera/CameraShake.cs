using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeDuration;
    private float shakeMagnitude;

    private void Start()
    {
        shakeDuration = GameSettings.Instance.GetCameraShakeDuration();
        shakeMagnitude = GameSettings.Instance.GetCameraShakeMagnitude();
    }
    public void ShakingCamera()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            
            elapsed += Time.deltaTime;
            
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
