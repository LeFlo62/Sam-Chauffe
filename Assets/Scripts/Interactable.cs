using UnityEngine;

namespace SamChauffe
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact();

        public void HoverEnter()
        {
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
    }
}
