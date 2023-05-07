using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollisionInteraction : MonoBehaviour
{
    public ParticleSystem collectParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(collectParticles, transform.position, Quaternion.identity);
            GameObject gate = GameObject.Find("Exit_Gate");
            GameObject spawn = GameObject.Find("KeySpawner");
            Destroy(gameObject);
            if (gate)
            {
                Destroy(gate);
            }
            if (spawn)
            {
                Destroy(spawn);
            }
        }
    }
}
