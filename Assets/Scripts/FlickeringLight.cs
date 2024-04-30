using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    // this script will do both flickering and color changing lights.
    public bool isFlickering = false;
    public float timeDelay;

    private Light lightComponent;

    private bool isCoroutineRunning = false; // Flag to track if the coroutine is running


    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(flickeringLight());
            isCoroutineRunning = true; // Set to true when the coroutine starts
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

        // generate a random color
        Color randomColor = Random.ColorHSV();

        // apply the random color to the light component
        this.gameObject.GetComponent<Light>().color = randomColor;

        timeDelay = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
        isCoroutineRunning = false;
    }

    // the purpose is to stop flickering before using toggle light script
    public void StopFlickering()
    {
        isFlickering = false;
        // Optionally, you can also stop the coroutine if it's running
        if (isCoroutineRunning)
        {
            StopCoroutine(flickeringLight());
            isCoroutineRunning = false;
        }
    }
}
