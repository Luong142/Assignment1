using UnityEngine;
using System.Collections;
using System;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> WorldTimeUpdate;

    [SerializeField]
    private float dayLength;

    private TimeSpan currentTime;

    private float minuteLength => dayLength / WorldTimeConstants.MinutesInDay;

    private void Start()
    {
        StartCoroutine(AddMinute());
    }


    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        WorldTimeUpdate?.Invoke(this, currentTime);
        yield return new WaitForSeconds(minuteLength);
        StartCoroutine(AddMinute());
    }


}
