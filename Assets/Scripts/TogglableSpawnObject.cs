using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Gizmos.color = objectOn.GetComponent<Renderer>().sharedMaterial.color;
            Gizmos.DrawWireMesh(objectOn.GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, transform.localScale);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f, 1f) < probability)
        {
            Instantiate(objectOn, transform.position, transform.rotation, transform);
        }
        else
        {
            Instantiate(objectOff, transform.position, transform.rotation, transform);
        }
    }
}
