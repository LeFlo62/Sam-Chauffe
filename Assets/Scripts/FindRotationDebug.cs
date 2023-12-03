using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    public class FindRotationDebug : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            // Rotation to world space

            Gizmos.DrawLine(transform.position, transform.position + transform.parent.rotation * transform.localRotation * Vector3.forward * 10f);

        }
    }
}
