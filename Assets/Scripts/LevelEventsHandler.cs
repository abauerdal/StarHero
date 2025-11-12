using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LevelEventsHandler : MonoBehaviour
{
    public AudioSource musicSource;

    public static double songTime = 0;

    public class LevelEvent
    {
        public float time;
        public Action action;
        public bool triggered = false;
    }

    public List<LevelEvent> levelEvents = new List<LevelEvent>();

    double songStartDSPTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songStartDSPTime = AudioSettings.dspTime;
        musicSource.PlayScheduled(songStartDSPTime);
    }

    // Update is called once per frame
    void Update()
    {
        songTime = AudioSettings.dspTime - songStartDSPTime;

        foreach (var e in levelEvents)
        {
            if (!e.triggered && songTime >= e.time)
            {
                e.triggered = true;
                e.action?.Invoke();
            }
        }
    }
}
