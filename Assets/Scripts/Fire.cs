using UnityEngine;
using System.Collections; 

namespace SamChauffe
{
    public class Fire : MonoBehaviour
    {
        public float particleStopTime = 0.5f;
        public double points = 1;
        private ParticleSystem fireParticles;
        private bool isStopping = false;

        void Start()
        {
            fireParticles = GetComponentInChildren<ParticleSystem>();
        }

        public virtual void Extinguish()
        {
            if (!isStopping)
            {
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

            // Manage score after the particule system stops emitting particules
            ScoreManager.score += points;
            Debug.Log("Score: " + ScoreManager.score);
        }
    }
}
