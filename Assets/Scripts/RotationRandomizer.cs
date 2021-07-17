using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRandomizer : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    float numNormal;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            CheckRotation();
        }
    }

    Quaternion GetRandomRotation()
    {
        bool flip = UnityEngine.Random.Range(0.0f, 1.0f) > .5;
        float angle = UnityEngine.Random.Range(10.0f, 170.0f);
        angle *= flip ? -1 : 1;
        return Quaternion.Euler(0, 0, angle);
    }


    void CheckRotation()
    {
        var flip = UnityEngine.Random.Range(0.0f, 1.0f);
        if (flip > numNormal)
        {
            transform.localRotation = GetRandomRotation();
        }
        else
        {
            transform.localRotation = Quaternion.identity;
        }
    }
}
