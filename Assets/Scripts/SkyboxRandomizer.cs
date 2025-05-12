using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRandomizer : MonoBehaviour
{
    public Material[] skyboxMaterials;

    void Start()
    {
        if (skyboxMaterials != null && skyboxMaterials.Length > 0)
        {
            int randomIndex = Random.Range(0, skyboxMaterials.Length);
            RenderSettings.skybox = skyboxMaterials[randomIndex];
            //Update Global Illumiation with new skybox
            DynamicGI.UpdateEnvironment(); 
        }
        else
        {
            Debug.LogWarning("No skybox materials ");
        }
    }
}
