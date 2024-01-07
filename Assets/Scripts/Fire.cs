using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace SamChauffe
{
    public class Fire : MonoBehaviour
    {
        public GameObject flamePrefab;
        public float particleStopTime = 0.5f;
        private ParticleSystem fireParticles;
        private bool isStopping = false;
        private AudioSource audioSource;
        
        // Variables for fire propagation
        private float spreadDelay = 5.0f;
        private float elapsedTime = 0f;
        public float minDistanceBetweenFlames = 2f;
        private float maxRandomOffsetX = 3f;
        private float maxRandomOffsetZ = 3f;
        private int numberOfFlames = 5;

        void Start()
        {
            fireParticles = GetComponentInChildren<ParticleSystem>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= spreadDelay && fireParticles.isPlaying && numberOfFlames>0)
            {
                SpreadFire();
                elapsedTime = 0f;
                numberOfFlames--;
            }
        }

        void SpreadFire()
        {
            int attempt = 3;
            Vector3 randomPosition;
            do {
                randomPosition = GetRandomPosition();
                attempt--;
            } while(IsTooCloseToOtherFlames(randomPosition) && attempt>0);

            // Add new flame to the scene only if the new random position is not already taken by another flame
            if(attempt>0 && GlobalVariables.IsPositionWithinRange(randomPosition)) {
                GameObject newFlame = Instantiate(flamePrefab, randomPosition, transform.rotation);
                GlobalVariables.flamesPositionSet.Add(randomPosition);
            }
        }

        Vector3 GetRandomPosition()
        {
            Vector3 randomPosition;

            // Calculate random offsets within the specified range for both X and Z axes
            float randomOffsetX = Random.Range(-maxRandomOffsetX, maxRandomOffsetX);
            float randomOffsetZ = Random.Range(-maxRandomOffsetZ, maxRandomOffsetZ);

            // Calculate the position based on the random offsets
            randomPosition = transform.position + new Vector3(randomOffsetX, 0f, randomOffsetZ);

            return randomPosition;
        }

        bool IsTooCloseToOtherFlames(Vector3 position)
        {
            // Check if the position is too close to any previously spawned flame positions
            foreach (Vector3 spawnedPosition in GlobalVariables.flamesPositionSet)
            {
                float distance = Vector3.Distance(position, spawnedPosition);
                if (distance < minDistanceBetweenFlames)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Extinguish()
        {
            if (!isStopping)
            {   
                ScoreManager.score += 10;
                StartCoroutine(StopParticlesOverTime());
            }
        }

        IEnumerator StopParticlesOverTime()
        {
            isStopping = true;
            float elapsedTime = 0f;
            float startEmissionRate = fireParticles.emission.rateOverTime.constant;

            while (elapsedTime < particleStopTime)
            {
                float t = elapsedTime / particleStopTime;
                float currentEmissionRate = Mathf.Lerp(startEmissionRate, 5f, t);

                ParticleSystem.EmissionModule emissionModule = fireParticles.emission;
                emissionModule.rateOverTime = currentEmissionRate;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure emission rate is zero when the loop ends
            ParticleSystem.EmissionModule finalEmissionModule = fireParticles.emission;
            finalEmissionModule.rateOverTime = 0f;
            fireParticles.Stop();

            Destroy(flamePrefab);
            // // Stop fire sound
            // if(audioSource)
            // {
            //     audioSource.Stop();
            // }
            // Manage score after the particule system stops emitting particules
        }
    }
}
