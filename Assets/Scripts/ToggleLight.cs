using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    // toggle all lights in scene
    [SerializeField]
    GameObject spotLights;

    [SerializeField]
    GameObject pointLights;

    public void ToggleAllLights()
    {
        // toggle all spotlights
        Light[] spotLightsArray = spotLights.GetComponentsInChildren<Light>();
        foreach (Light spotLight in spotLightsArray)
        {
            FlickerControl flickerControl = spotLight.GetComponent<FlickerControl>();
            if (flickerControl != null)
            {
                flickerControl.enabled = !flickerControl.enabled; // Disable the FlickerControl script
            }
            spotLight.enabled = !spotLight.enabled;
        }

        // toggle all point lights
        Light[] pointLightsArray = pointLights.GetComponentsInChildren<Light>();
        foreach (Light pointLight in pointLightsArray)
        {
            FlickerControl flickerControl = pointLight.GetComponent<FlickerControl>();
            if (flickerControl != null)
            {
                flickerControl.enabled = !flickerControl.enabled; // Disable the FlickerControl script
            }

            pointLight.enabled = !pointLight.enabled;
        }
    }
}
