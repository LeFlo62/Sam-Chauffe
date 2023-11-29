using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabbableObject : MonoBehaviour
    {
        public static float pickupForce = 10f;

        private Transform objectGrabPointTransform;
        private Rigidbody objectRigidBody;

        private bool useGravity;
        private float drag;
        private RigidbodyConstraints constraints;

        private Vector3 velocity;
        private Vector3 position;

        public void Awake()
        {
            this.objectRigidBody = GetComponent<Rigidbody>();
        }


        public void Grab(Transform objectGrabPointTransform)
        {
            this.objectGrabPointTransform = objectGrabPointTransform;
            objectRigidBody.velocity = Vector3.zero;
            objectRigidBody.angularVelocity = Vector3.zero;

            this.useGravity = objectRigidBody.useGravity;
            objectRigidBody.useGravity = false;

            this.drag = objectRigidBody.drag;
            objectRigidBody.drag = 10f;

            this.constraints = objectRigidBody.constraints;
            objectRigidBody.constraints = RigidbodyConstraints.FreezeRotation;

            this.transform.SetParent(objectGrabPointTransform);
        }

        public void Drop()
        {
            objectRigidBody.useGravity = this.useGravity;
            objectRigidBody.drag = this.drag;
            objectRigidBody.AddForce(this.velocity * pickupForce / objectRigidBody.mass, ForceMode.VelocityChange);
            objectRigidBody.constraints = this.constraints;
            this.transform.SetParent(null);
        }

        public void Move()
        {
            if (Vector3.Distance(transform.position, objectGrabPointTransform.position) > 0.1f)
            {
                Vector3 moveDirection = (objectGrabPointTransform.position - transform.position);
                objectRigidBody.velocity = moveDirection * pickupForce;
            }
        }

        private void FixedUpdate()
        {
            this.velocity = this.transform.position - this.position;
            this.position = this.transform.position;
        }
    }
}
