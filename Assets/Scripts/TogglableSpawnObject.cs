using UnityEngine;

namespace SamChauffe
{
    public class TogglableSpawnObject : MonoBehaviour
    {

        public GameObject objectOn;
        public GameObject objectOff;

        [Range(0, 1)]
        public float probability;

        private void OnDrawGizmos()
        {
            if (objectOn != null)
            {
                Renderer renderer = objectOn.GetComponent<Renderer>();
                if(renderer != null)
                {
                    MeshFilter meshFilter = objectOn.GetComponent<MeshFilter>();
                    Gizmos.color = renderer.sharedMaterial.color;
                    Gizmos.DrawWireMesh(meshFilter.sharedMesh, transform.position, transform.rotation, transform.localScale);
                } else
                {
                    Gizmos.DrawWireCube(transform.position, transform.localScale);
                }

            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (Random.Range(0f, 1f) < probability)
            {
                Instantiate(objectOn, transform.position, transform.rotation, transform);
            }
            else
            {
                if(objectOff != null)
                {
                    Instantiate(objectOff, transform.position, transform.rotation, transform);
                }
            }
        }
    }
}
