using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    public interface GrabInteractableObject
    {
        void Interact();

        void StopInteracting();
    }
}
