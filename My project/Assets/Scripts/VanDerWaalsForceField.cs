using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanDerWaalsForceField : MonoBehaviour
{
     public Transform sheet1; // Reference to the first graphene sheet
    public Transform sheet2; // Reference to the second graphene sheet
    public ParticleSystem particleSystem; // Reference to the particle system
    public float maxForceDistance = 0.5f; // Maximum distance for noticeable VDW forces
    public float optimalDistance = 0.335f; // Optimal distance for strong forces

    private ParticleSystem.MainModule mainModule;

    // Start is called before the first frame update
    void Start()
    {
         // Get the particle system's main module
        mainModule = particleSystem.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the sheets
        float distance = Vector3.Distance(sheet1.position, sheet2.position);

        // Adjust particle intensity based on distance
        float intensity = Mathf.Clamp01(1.0f - Mathf.Abs(distance - optimalDistance) / maxForceDistance);

        // Update particle color (e.g., stronger forces = redder particles)
        mainModule.startColor = new ParticleSystem.MinMaxGradient(
            Color.Lerp(Color.blue, Color.red, intensity)
        );

        // Adjust particle emission rate dynamically
        var emission = particleSystem.emission;
        emission.rateOverTime = intensity * 100.0f; // Scale particle density with intensity
    }
    
}
