using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light))]
public class WorldLight : MonoBehaviour
{
    private Light light;

    [SerializeField]
    private WorldTime worldTime;

    [SerializeField]
    private Gradient gradient;

    private void Awake()
    {
        light = GetComponent<Light>();
        worldTime.WorldTimeUpdate += OnWorldTimeChanged;

    }

    private void OnDestroy()
    {
        worldTime.WorldTimeUpdate -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        light.color = gradient.Evaluate(PercentOfDay(newTime));
    }


    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }
}
