using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticles : MonoBehaviour
{
    ParticleSystem particleSystem;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    public void SpeedUpParticles(float acceleration)
    {
        var velocityOverLifetime = particleSystem.velocityOverLifetime;
        velocityOverLifetime.xMultiplier += acceleration;
        velocityOverLifetime.yMultiplier += acceleration;
        velocityOverLifetime.zMultiplier += acceleration;
    }
}
