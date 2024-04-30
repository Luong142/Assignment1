using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingSpotLights : MonoBehaviour
{
    // we need to find the spot light
    [SerializeField]
    Light spotLight;

    // speed here
    public float swingSpeed = 5f;

    public float translateSpeed = 1.0f;

    // asign vector, change y
    public Vector3 swingAxis = new Vector3(0, 1, 0);

    private bool isSwinging = true; // flat here

    private Quaternion originalRotation; // Store the original rotation

    void Start()
    {
        // Store the original rotation of the spotlight at the start
        spotLight = GetComponent<Light>();
        originalRotation = spotLight.transform.rotation;
    }

    private void Update()
    {
        swingingLight();
    }

    public void swingingLight()
    {
        // get the Transform component of each spotlight
        Transform spotLightTransform = spotLight.transform;

        // then rotate the spotlight around the specified axis
        spotLightTransform.Rotate(swingAxis * swingSpeed * Time.deltaTime);

        // check now
        if (spotLightTransform.eulerAngles.x >= 20f && spotLightTransform.eulerAngles.x <= 23f)
        {
            // reset the spotlight's rotation to its original state
            spotLightTransform.rotation = originalRotation;
        }
    }
}
