using UnityEditor;
using UnityEngine;

public class SkyboxToCubemapWindow : ScriptableWizard
{
    public Object cameraObj;
    public Object cubemapObj;

    [MenuItem("Tools/Skybox to Cubemap")]
    public static void SkyboxToCubemapCall()
    {
        ScriptableWizard.DisplayWizard<SkyboxToCubemapWindow>("Skybox Capture", "Capture");
    }

    protected override bool DrawWizardGUI()
    {
        GUILayout.Label("Assign a camera to capture the environment from");
        cameraObj = EditorGUILayout.ObjectField(cameraObj, typeof(Camera), true);
        GUILayout.Label("Assign a cubemap to overwrite with the captured environment");
        cubemapObj = EditorGUILayout.ObjectField(cubemapObj, typeof(Cubemap), true);

        return true;
    }

    private void OnWizardCreate()
    {
        if (cameraObj == null || cubemapObj == null)
        {
            EditorUtility.DisplayDialog("Error", $"The camera or the cubemap is invalid.", "OK");
            return;
        }

        if ((cameraObj as Camera).RenderToCubemap(cubemapObj as Cubemap))
        {
            EditorUtility.DisplayDialog("Done", $"The environment has been captured into the cubemap.", "OK");
        }
        else
        {
            EditorUtility.DisplayDialog("Error", $"Your device does not support rendering to cubemap", "OK");
        }
    }
}
