using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartiSystem : MonoBehaviour
{
    // The particle systems to play when the object hits the ground
    public ParticleSystem[] hitParticles;

    private bool hasHitGround = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object has hit the ground and hasn't already played particles
        if (collision.gameObject.CompareTag("Ground") && !hasHitGround)
        {
            // Set the flag to true to prevent playing particles multiple times
            hasHitGround = true;

            // Play all of the hit particles at the same time
            foreach (ParticleSystem particle in hitParticles)
            {
                particle.Play();
            }
        }
    }

    public void ParticleStuff()
    {
        foreach (ParticleSystem particle in hitParticles)
        {
            particle.Play();
        }
    }
}
