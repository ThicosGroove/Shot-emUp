using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemHandler : MonoBehaviour
{
    [SerializeField] private Color particleColor;
    [SerializeField] private ParticleSystem particle;

    public bool canRunParticle; // usado no EnemyHealth e PlayerSpawnManager

    private void Start()
    {
        var main = particle.gameObject.GetComponentInChildren<ParticleSystem>().main;
        main.startColor = particleColor;
    }

    void Update()
    {
        if (canRunParticle)
            PlayParticle();
    }

    private void PlayParticle()
    {
        canRunParticle = false;
        particle.Play();
    }


}
