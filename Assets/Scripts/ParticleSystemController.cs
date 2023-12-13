using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe 
{
    public class ParticleSystemController : MonoBehaviour
    {
        private bool emitParticles;
        private ParticleSystem particleSystem;
        public float maxParticles = 200;
        public float emissionRateIncreaseSpeed = 5f;

        private void Start()
        {
            particleSystem = GetComponent<ParticleSystem>();
            particleSystem.startLifetime = 0.6f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                emitParticles = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                emitParticles = false;
            }
            // Control particle emission based on mouse and keyboard interaction
            if (emitParticles)
            {
                EmitParticles();
            }
            else
            {
                StopEmittingParticles();
            }
        }

        private void EmitParticles()
        {
            particleSystem.startLifetime = 0.6f;
            var emission = particleSystem.emission;
            if (emission.rateOverTime.constant < maxParticles)
            {
                // Increase particle emission rate smoothly
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(
                    emission.rateOverTime.constant + emissionRateIncreaseSpeed * Time.deltaTime
                );
            }
        }

        private void StopEmittingParticles()
        {
            var emission = particleSystem.emission;
            if (emission.rateOverTime.constant > 0)
            {
                emission.rateOverTime = 0;
            }
        }
    }
}