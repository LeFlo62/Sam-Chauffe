using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SamChauffe
{
    public class FireExtinguisher : MonoBehaviour, InteractableObject
    {
        public Transform spitTransform;

        [Range(0f, 10f)]
        public float spitDistance;

        public LayerMask fireMask;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(spitTransform.position, spitTransform.forward * spitDistance);
        }

        public void Interact()
        {
            if (Physics.Raycast(spitTransform.position, spitTransform.forward, out RaycastHit hit, spitDistance, fireMask))
            {
               if (hit.transform.TryGetComponent(out Fire fire))
                {
                    fire.Extinguish();
                }
            }
        }
    }
}
