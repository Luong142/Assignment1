using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class WorldTimeScheduler : MonoBehaviour
{
    [SerializeField]
    private WorldTime worldTime;

    [SerializeField]
    private List<Schedule> schedules;

    private void Start()
    {
        worldTime.WorldTimeUpdate += CheckSchedule;
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeUpdate -= CheckSchedule;
    }

    private void CheckSchedule(object sender, TimeSpan newTime)
    {
        var schedule = schedules.FirstOrDefault
            (s => s.hour == newTime.Hours && s.minute == newTime.Minutes);

        schedule?.action?.Invoke();
    }

    [Serializable]
    private class Schedule
    {
        public int hour;
        public int minute;

        public UnityEvent action;
    }

}
