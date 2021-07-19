using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool;

    public void SpawnParticle(Player player)
    {
        pool.GetAndActivateObject(player.transform.position);
    }
}
