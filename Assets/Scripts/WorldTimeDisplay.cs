using System;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private WorldTime WorldTime;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        WorldTime.WorldTimeUpdate += OnWorldTimeUpdated;

    }

    private void OnWorldTimeUpdated(object sender, TimeSpan newTime)
    {
        text.SetText("Time Display: " + newTime.ToString(@"hh\:mm")); // @ is format the string. Similar to String.format() in Java.
    }
}
