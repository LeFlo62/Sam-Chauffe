using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

namespace SamChauffe
{
    public class PlayerPickupObject : MonoBehaviour
    {
        public static float pickupRange = 3f;

        public Transform playerCameraTransform;
        public Transform objectGrabPointTransform;

        private GrabbableObject hoveredObject;
        private GrabbableObject grabbedObject;

        // Update is called once per frame
        void Update()
        {
            if (grabbedObject == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, pickupRange))
                {
                    if (hit.transform.TryGetComponent(out hoveredObject))
                    {
                        hoveredObject.HoverEnter();

                        if (Input.GetMouseButtonDown(0))
                        {
                            grabbedObject = hoveredObject;
                            hoveredObject = null;
                            grabbedObject.Grab(objectGrabPointTransform);
                        }
                    }
                }

                var grabbables = FindObjectsOfType<GrabbableObject>();
                foreach (var grabbable in grabbables)
                {
                    if (grabbable == hoveredObject) continue;
                    grabbable.HoverExit();
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    grabbedObject.Move();
                }

                if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.E))
                {
                    grabbedObject.Activate();
                } else
                {
                    grabbedObject.Deactivate();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    grabbedObject.Deactivate();

                    grabbedObject.Drop();
                    grabbedObject = null;
                }
            }

        }
    }
}
