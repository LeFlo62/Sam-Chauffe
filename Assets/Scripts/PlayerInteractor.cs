using UnityEngine;

namespace SamChauffe
{
    public class PlayerInteractor : MonoBehaviour
    {
        public Transform playerCameraTransform;
        public float maxDistance;

        void Start()
        {

        }

        void Update()
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, maxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    interactable.HoverEnter();
                    if (Input.GetMouseButtonDown(0))
                    {
                        interactable.Interact();
                    }
                }
            }
            else
            {
                var interactables = FindObjectsOfType<Interactable>();
                foreach (var interactable in interactables)
                {
                    interactable.HoverExit();
                }
            }

        }
    }
}
