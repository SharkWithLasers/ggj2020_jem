using UnityEngine;
using UnityEditor;

public class SpritePPUPostProcessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.spritePixelsPerUnit = 32;
    }
}