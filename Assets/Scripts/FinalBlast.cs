using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlast : MonoBehaviour
{
    [SerializeField]
    GameEventSO onCharge;

    [SerializeField]
    GameEventSO onFire;

    public void ChargeSound()
    {
        onCharge.Invoke();
    }

    public void FireSound()
    {
        onFire.Invoke();
    }
}
