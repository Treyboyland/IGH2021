using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool;

    [SerializeField]
    float damageTimeScale;

    int damageCount = 0;


    public void HandleDamage(Vector3 position)
    {
        StartCoroutine(DoDamageThing(position));
    }

    IEnumerator DoDamageThing(Vector3 position)
    {
        damageCount++;
        Time.timeScale = damageTimeScale;
        var particle = pool.GetObject();
        particle.transform.position = position;
        particle.gameObject.SetActive(true);

        while (particle.gameObject.activeInHierarchy)
        {
            yield return null;
        }

        damageCount = damageCount - 1 >= 0 ? damageCount - 1 : 0;
        if (damageCount == 0)
        {
            Time.timeScale = 1;
        }
    }
}
