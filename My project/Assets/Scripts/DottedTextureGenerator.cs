using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedTextureGenerator : MonoBehaviour
{
    public Material targetMaterial; // Assign the material to apply the texture to
    public int textureSize = 256;   // Size of the texture
    public int dotSize = 16;        // Size of each dot

    
    // Start is called before the first frame update
    void Start()
    {
       // Create a new texture
        Texture2D dottedTexture = new Texture2D(textureSize, textureSize);
        dottedTexture.wrapMode = TextureWrapMode.Repeat;
        dottedTexture.filterMode = FilterMode.Point;

        // Fill the texture with transparency
        Color[] pixels = new Color[textureSize * textureSize];
        for (int y = 0; y < textureSize; y++)
        {
            for (int x = 0; x < textureSize; x++)
            {
                // Create a pattern of dots
                if ((x % dotSize == 0) && (y % dotSize == 0))
                {
                    pixels[y * textureSize + x] = Color.black; // Black dot
                }
                else
                {
                    pixels[y * textureSize + x] = Color.clear; // Transparent
                }
            }
        }

        // Apply the pixel colors to the texture
        dottedTexture.SetPixels(pixels);
        dottedTexture.Apply();

        // Assign the texture to the material
        if (targetMaterial != null)
        {
            targetMaterial.mainTexture = dottedTexture;
            targetMaterial.SetTexture("_MainTex", dottedTexture); // Ensure proper binding
        }
        else
        {
            Debug.LogWarning("No target material assigned.");
        }
    }
    
    void Update()
    {
        
    }
}
