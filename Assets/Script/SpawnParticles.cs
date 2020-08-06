using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
   [SerializeField]
    public GameObject Particle;
    [SerializeField]
    [Range(0f,5f)]
    public float time;

    public void Spawn()
    {
        GameObject particle = Instantiate(Particle, transform.position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f)) as GameObject;
        Destroy(particle, time);

    }
}
