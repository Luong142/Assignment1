using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject[] lights = GameObject.FindGameObjectsWithTag("WayfindingLight");

            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = !light.GetComponent<Light>().enabled;
            }
        }
    }
}
