using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchDimensions : MonoBehaviour
{
    public GameObject grapheneSheet; // Reference to the graphene sheet
    public ParticleSystem particleSystem; // Reference to the particle system


    // Start is called before the first frame update
    void Start()
    {
        // Get the MeshRenderer bounds of the graphene sheet
        MeshRenderer renderer = grapheneSheet.GetComponent<MeshRenderer>();
        Vector3 sheetSize = renderer.bounds.size;

        // Adjust the particle system shape module
        var shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = new Vector3(sheetSize.x, 0.5f, sheetSize.z); // Set height to 0.5
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//adjust position of field -- idk if this did anything or not
    void AlignOtherObject(Transform otherObject)
{
    MeshFilter meshFilter = GetComponent<MeshFilter>();
    if (meshFilter != null && meshFilter.mesh != null)
    {
        Vector3 offset = meshFilter.mesh.bounds.center;
        otherObject.position += transform.TransformPoint(offset) - transform.position;
        Debug.Log($"Aligned {otherObject.name} to match offset {offset}");
    }
    else
    {
        Debug.LogWarning("Mesh or MeshFilter is missing!");
    }
}

}
