using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    public class GlobalVariables : MonoBehaviour
    {
        public static HashSet<Vector3> flamesPositionSet = new HashSet<Vector3>();
        // Limit of the building
        public static float minX = 0f;
        public static float maxX = 48f;
        public static float minZ = 0f;
        public static float maxZ = 72;

        public static bool IsPositionWithinRange(Vector3 position)
        {
            return position.x >= minX && position.x <= maxX && position.z >= minZ && position.z <= maxZ;
        }
    }
       
}
