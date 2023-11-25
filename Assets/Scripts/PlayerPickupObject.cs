using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickupObject : MonoBehaviour
{
    public static float pickupRange = 3f;
    
    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public LayerMask pickupLayerMask;

    private GrabbableObject grabbedObject;

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject == null){
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, pickupRange, pickupLayerMask))
                {
                    if (hit.transform.TryGetComponent(out grabbedObject))
                    {
                        grabbedObject.Grab(objectGrabPointTransform);
                    }
                }
            }
        } else
        {
            if (Input.GetMouseButtonUp(0))
            {
                grabbedObject.Drop();
                grabbedObject = null;
            }
            if (Input.GetMouseButton(0))
            {
                grabbedObject.Move();
            }
        }
        
    }
}
