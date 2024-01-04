using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SamChauffe
{
    public class FireExtinguisher : MonoBehaviour, GrabInteractableObject
    {
        [Range(0f, 10f)]
        public float spitDistance;
        public LayerMask fireMask;
        public ParticleSystem snowParticles;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(snowParticles.transform.position, snowParticles.transform.forward * spitDistance);
        }

        public void Interact()
        {
            if (!snowParticles.isEmitting)
            {
                snowParticles.Play();
            }
            if (Physics.Raycast(snowParticles.transform.position, snowParticles.transform.forward, out RaycastHit hit, Mathf.Infinity, fireMask))
            {
                if (hit.transform.TryGetComponent(out Fire fire))
                {
                    fire.Extinguish();
                }
            }
        }

        public void StopInteracting()
        {
            snowParticles.Stop();
        }
    }
}
