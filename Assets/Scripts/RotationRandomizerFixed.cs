using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRandomizerFixed : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    float numNormal;

    [SerializeField]
    List<float> angles;


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
        int index = UnityEngine.Random.Range(0, angles.Count);
        float angle = angles[index];
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

