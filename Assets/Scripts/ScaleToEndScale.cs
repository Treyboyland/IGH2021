using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToEndScale : MonoBehaviour
{
    [SerializeField]
    SpawningPlatform platform;

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    float secondsToAnimate;

    Vector3 EvaluateScale(float normalized)
    {
        var value = Vector3.Lerp(new Vector3(), platform.EndScale, curve.Evaluate(normalized));
        return value;
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {
        float elapsed = 0;

        while (elapsed < secondsToAnimate)
        {
            elapsed += Time.deltaTime;
            transform.localScale = EvaluateScale(elapsed / secondsToAnimate);
            yield return null;
        }
        transform.localScale = EvaluateScale(1);

    }
}
