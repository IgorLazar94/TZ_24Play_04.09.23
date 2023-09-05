using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void ShakingCamera()
    {
        Handheld.Vibrate();
        StartCoroutine(Shake(0.3f, 0.3f));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            
            elapsed += Time.deltaTime;
            
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
