using UnityEngine;
using System.Collections; 

namespace SamChauffe
{
    public class Fire : MonoBehaviour
    {
        public float particleStopTime = 2f;
        public double points = 1;
        private ParticleSystem particleSystem;
        private bool isStopping = false;

        void Start()
        {
            particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        public void Extinguish()
        {
            if (!isStopping)
            {
                StartCoroutine(StopParticlesOverTime());
            }
        }

        IEnumerator StopParticlesOverTime()
        {

            float elapsedTime = 0f;
            float startEmissionRate = particleSystem.emission.rateOverTime.constant;

            while (elapsedTime < particleStopTime)
            {
                float t = elapsedTime / particleStopTime;
                float currentEmissionRate = Mathf.Lerp(startEmissionRate, 0f, t);

                ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
                emissionModule.rateOverTime = currentEmissionRate;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure emission rate is zero when the loop ends
            ParticleSystem.EmissionModule finalEmissionModule = particleSystem.emission;
            finalEmissionModule.rateOverTime = 0f;
            particleSystem.Stop();

            isStopping = false;

            // Manage score after the particule system stops emitting particules
            ScoreManager.score += points;
            Debug.Log(ScoreManager.score);
        }
    }
}
