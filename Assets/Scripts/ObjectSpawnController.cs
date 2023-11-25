using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public GameObject objectPrefab;

    public int spawnAmount = 1;
    
    public Transform[] spawnPoints;

    private void OnDrawGizmos()
    {
        if(objectPrefab != null)
        {
            Gizmos.color = objectPrefab.GetComponent<Renderer>().sharedMaterial.color;
            foreach (Transform spawnPoint in spawnPoints)
            {
                Gizmos.DrawWireMesh(objectPrefab.GetComponent<MeshFilter>().sharedMesh, spawnPoint.position, spawnPoint.rotation, spawnPoint.localScale);
            }
        }
    }

    private void Start()
    {
        if(spawnAmount > spawnPoints.Length)
        {
            spawnAmount = spawnPoints.Length;
        }
        
        int[] indexes = RandomArray(spawnPoints.Length);

        for (int i = 0; i < spawnAmount; ++i)
        {
            Instantiate(objectPrefab, spawnPoints[indexes[i]].position, spawnPoints[indexes[i]].rotation, spawnPoints[indexes[i]]);
        }
    }

    //
    // Summary:
    //     Returns a shuffled array of indexes from 0 to length - 1
    //
    // Parameters:
    //   length:
    //     The length of the array
    private int[] RandomArray(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; ++i)
        {
            array[i] = i;
        }

        for (int i = 0; i < length; ++i)
        {
            int temp = array[i];
            int randomIndex = Random.Range(i, length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }

        return array;
    }
}
