using UnityEngine;

namespace SamChauffe
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabbableObject : MonoBehaviour
    {
        public static float pickupForce = 10f;

        public Transform grabTransform;

        private Transform objectGrabPointTransform;
        private Rigidbody objectRigidBody;

        private bool useGravity;
        private float drag;
        private RigidbodyConstraints constraints;

        private Vector3 velocity;
        private Vector3 position;

        private bool grabbed = false;
        private bool vrInteract = false;

        public void Awake()
        {
            this.objectRigidBody = GetComponent<Rigidbody>();
        }

        public void Update()
        {
            if(vrInteract)
            {
                Activate();
            }
        }

        public void EnableGrabbed()
        {
            grabbed = true;
        }

        public void DisableGrabbed()
        {
            grabbed = false;
        }

        public void Grab(Transform objectGrabPointTransform)
        {
            this.velocity = Vector3.zero;
            this.position = objectGrabPointTransform.position;

            this.objectGrabPointTransform = objectGrabPointTransform;
            objectRigidBody.velocity = Vector3.zero;
            objectRigidBody.angularVelocity = Vector3.zero;

            this.useGravity = objectRigidBody.useGravity;
            objectRigidBody.useGravity = false;

            this.drag = objectRigidBody.drag;
            objectRigidBody.drag = 10f;

            this.transform.SetParent(objectGrabPointTransform);
            if(this.grabTransform != null)
            {
                this.transform.position = this.grabTransform.position;

                this.transform.localRotation = this.grabTransform.localRotation;
            }

            this.constraints = objectRigidBody.constraints;
            objectRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public void Drop()
        {
            grabbed = false;
            objectRigidBody.useGravity = this.useGravity;
            objectRigidBody.drag = this.drag;
            objectRigidBody.AddForce(this.velocity * pickupForce / objectRigidBody.mass, ForceMode.VelocityChange);
            objectRigidBody.constraints = this.constraints;
            this.transform.SetParent(null);
        }

        public void Move()
        {
            Vector3 position = grabTransform != null ? grabTransform.position : transform.position;

            if (Vector3.Distance(position, objectGrabPointTransform.position) > 0.1f)
            {
                Vector3 moveDirection = (objectGrabPointTransform.position - position);
                objectRigidBody.velocity = moveDirection * pickupForce;
            }
        }

        private void FixedUpdate()
        {
            Vector3 position = grabTransform != null ? grabTransform.position : transform.position;

            this.velocity = position - this.position;
            this.position = position;
        }

        public void Activate()
        {
            GrabInteractableObject[] interactables = GetComponentsInParent<GrabInteractableObject>();
            if (interactables != null)
            {
                foreach (var item in interactables)
                {
                    item.Interact();
                }
            }
        }

        public void Deactivate()
        {
            GrabInteractableObject[] interactables = GetComponentsInParent<GrabInteractableObject>();
            if (interactables != null)
            {
                foreach (var item in interactables)
                {
                    item.StopInteracting();
                }
            }
        }

        public void HoverEnter()
        {
            if(grabbed) { return; }
            if (gameObject.TryGetComponent<Outline>(out Outline outline))
            {
                outline.enabled = true;
            }
        }

        public void HoverExit()
        {
            if (gameObject.TryGetComponent<Outline>(out Outline outline))
            {
                outline.enabled = false;
            }
        }

        public void VrActivate()
        {
            vrInteract = true;
            Activate();
        }

        public void VrDeactivate()
        {
            vrInteract = false;
            Deactivate();
        }
    }
}
