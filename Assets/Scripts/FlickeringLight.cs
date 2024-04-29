using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    // this script will do both flickering and color changing lights.
    public bool isFlickering = false;
    public float timeDelay;

    private Light lightComponent;

    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(flickeringLight());
        }
    }

    IEnumerator flickeringLight()
    {
        isFlickering = true;

        // first
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.1f, 0.2f);
        yield return new WaitForSeconds(timeDelay);

        // second
        this.gameObject.GetComponent<Light>().enabled = true;

        // Generate a random color
        Color randomColor = Random.ColorHSV();

        // Apply the random color to the light component
        this.gameObject.GetComponent<Light>().color = randomColor;

        timeDelay = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
