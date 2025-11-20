using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
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

    bool paused = false;
    double pausedOffset = 0;
    double pauseStartDSP = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songStartDSPTime = AudioSettings.dspTime + 5f;
        musicSource.PlayScheduled(songStartDSPTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused) { 
            songTime = AudioSettings.dspTime - songStartDSPTime - pausedOffset;

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

    public void Restart()
    {
        songStartDSPTime = AudioSettings.dspTime + 5f;
        musicSource.PlayScheduled(songStartDSPTime);
        foreach(var e in levelEvents)
        {
            e.triggered = false;
        }
        paused = false;
        pausedOffset = 0;
        pauseStartDSP = 0;
    }

    public void Pause()
    {
        if (!paused) { 
            musicSource.Pause();
            paused = true;
            pauseStartDSP = AudioSettings.dspTime;
        }
    }

    public void Resume()
    {
        if (paused) {
            musicSource.UnPause();
            paused = false;
            pausedOffset += AudioSettings.dspTime - pauseStartDSP;
        }
    }
}
