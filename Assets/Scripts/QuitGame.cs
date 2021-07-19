using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGameQuit()
    {
#if UNITY_WEBGL
#elif UNITY_EDITOR
        EditorApplication.Beep();
#else
        Application.Quit();
#endif
    }
}
