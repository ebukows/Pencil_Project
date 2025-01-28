using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshViewerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.mesh != null)
        {
            Bounds bounds = meshFilter.mesh.bounds;
            Debug.Log($"Bounds Center: {bounds.center}, Extents: {bounds.extents}");
        }
        else
        {
            Debug.LogWarning("No MeshFilter or Mesh found!");
        }

       
    if (meshFilter != null && meshFilter.mesh != null)
    {
        Debug.Log($"Mesh Bounds Center: {meshFilter.mesh.bounds.center}");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
