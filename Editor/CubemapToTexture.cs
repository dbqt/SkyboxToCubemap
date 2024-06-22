using System.IO;
using UnityEditor;
using UnityEngine;

public class CubeMapToTextureWindow : ScriptableWizard
{
    public Object cubemapObj;
    public string savePath = "Assets/";

    [MenuItem("Tools/Cubemap to Textures")]
    public static void SkyboxToCubemapCall()
    {
        ScriptableWizard.DisplayWizard<CubeMapToTextureWindow>("Cubemap to Textures", "Convert");
    }

    protected override bool DrawWizardGUI()
    {
        GUILayout.Label("Assign a cubemap to convert to textures");
        cubemapObj = EditorGUILayout.ObjectField(cubemapObj, typeof(Cubemap), true);

        savePath = EditorGUILayout.TextField("Save path", savePath);

        return true;
    }

    private void OnWizardCreate()
    {
        if (string.IsNullOrEmpty(savePath) || cubemapObj == null)
        {
            EditorUtility.DisplayDialog("Error", $"The save path or the cubemap is invalid.", "OK");
            return;
        }

        ConvertCubemapToPNG();
    }

    private void ConvertCubemapToPNG()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        Cubemap cubemap = cubemapObj as Cubemap;
        int size = cubemap.width;

        // For each face
        for (int i = 0; i < 6; i++)
        {
            // Get texture
            CubemapFace face = (CubemapFace)i;
            Texture2D faceTexture = new Texture2D(size, size, TextureFormat.RGBA32, false);
            faceTexture.SetPixels(cubemap.GetPixels(face));
            faceTexture.Apply();

            // Write to file
            byte[] bytes = faceTexture.EncodeToPNG();
            string fileName = Path.Combine(savePath, cubemap.name + "_" + face.ToString() + ".png");
            File.WriteAllBytes(fileName, bytes);

            // Clean up memory
            DestroyImmediate(faceTexture);
        }

        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Done", $"The cubemap was converted into textures at {savePath}", "OK");
    }
}

