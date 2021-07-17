using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraAspect : MonoBehaviour
{
    [SerializeField]
    float width;

    [SerializeField]
    float height;

    [SerializeField]
    float threshold;

    [SerializeField]
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.aspect = width / height;
        //mainCamera.ResetAspect();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
