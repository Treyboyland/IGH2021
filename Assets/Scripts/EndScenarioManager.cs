using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenarioManager : MonoBehaviour
{
    static EndScenarioManager _instance;

    public static EndScenarioManager Manager { get { return _instance; } }

    [SerializeField]
    EndScenario defaultScenario;


    EndScenario finalScenario;

    public EndScenario FinalScenario
    {
        get
        {
            return finalScenario == null ? defaultScenario : finalScenario;
        }
        set
        {
            finalScenario = value;
        }
    }

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
