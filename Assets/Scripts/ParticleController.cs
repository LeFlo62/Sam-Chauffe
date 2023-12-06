using UnityEngine;
using System.Collections; 

namespace SamChauffe
{
    public class ParticleController : MonoBehaviour
    {
        public float particleStopTime = 2f;
        public double points = 0.25;
        private ParticleSystem particleSystem;
        private bool isStopping = false;

        void Start()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !isStopping)
            {
                StartCoroutine(StopParticlesOverTime());
            }
        }

        IEnumerator StopParticlesOverTime()
        {
            isStopping = true;

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

            isStopping = false;

            // Manage score after the particule system stops emitting particules
            ScoreManager.Score += points;
            Debug.Log(ScoreManager.Score);
        }
    }
}
