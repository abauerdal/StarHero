using UnityEngine;

public class NoteEvent
{
    public float time;
    public int lane;
}

public class NoteSpawner : MonoBehaviour
{
    public LevelEventsHandler levelEventsHandler;
    public GameObject[] lanePrefabs = new GameObject[4];
    public Transform[] laneSpawnPoints;

    static float BARS_TO_SECONDS = 240f / 140f;
    static float BEATS_TO_SECONDS = 60f / 140f;

    public NoteEvent[] chart = new NoteEvent[]
    {
        //Measure 1
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // BARS_TO_SECONDS * 0 --> Measure 1
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 }, // lane 0 is note u, lane 1 is note i, etc.
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        //Measure 2, etc.
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // BARS_TO_SECONDS * 1,2, etc. --> Measure 2,3 etc.
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 2) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 3) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        //M5
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 4) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 5) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 6) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 7) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        //M9
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 8) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 9) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 10) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 11) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        //M13
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 12) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 13) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 14) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 15) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        // Buildup Kind of thing
        new NoteEvent { time = (BARS_TO_SECONDS * 16) + (BEATS_TO_SECONDS / 2) * 0, lane = 2},
        new NoteEvent { time = (BARS_TO_SECONDS * 16) + (BEATS_TO_SECONDS / 2) * 2, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 16) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 16) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 16) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        // New melody
        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 17) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 17) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 17) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 17) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        
        new NoteEvent { time = (BARS_TO_SECONDS * 18) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 18) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 18) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 18) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 19) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 19) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 19) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 19) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 20) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 20) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 20) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 20) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 21) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 21) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 21) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 21) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 22) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 22) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 22) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 22) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 23) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 23) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 23) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 23) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 24) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 24) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 24) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 24) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 25) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 25) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 25) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 25) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 26) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 26) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 26) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 26) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 27) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 27) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 27) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 27) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 28) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 28) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 28) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 28) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 29) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 29) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 29) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 29) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 30) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 30) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 30) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 30) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 31) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 31) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 31) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 31) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        
        // New melody
        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 32) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 32) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 32) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 32) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 32) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 33) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 33) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 33) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 33) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 33) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 34) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 34) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 34) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 34) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 34) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 35) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 35) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 35) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 35) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 35) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 36) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 36) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 36) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 36) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 36) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 37) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 37) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 37) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 37) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 37) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 38) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 38) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 38) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 38) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 38) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 39) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 39) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 39) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 39) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 39) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 40) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 40) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 40) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 40) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 40) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 41) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 41) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 41) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 41) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 41) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 42) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 42) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 42) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 42) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 42) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 43) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 43) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 43) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 43) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 43) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 44) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 44) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 44) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 44) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 44) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 45) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 45) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 45) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 45) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 45) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 46) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 46) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 46) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 46) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 46) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 47) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 47) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 47) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 47) + (BEATS_TO_SECONDS / 2) * 5, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 47) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        // Drums
        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 48) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 49) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 50) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 51) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 52) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 53) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 54) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 55) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 56) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 57) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 58) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 59) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // BLOCK
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 60) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 61) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 62) + (BEATS_TO_SECONDS / 2) * 7, lane = 0 },

        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 3, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 63) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // Back to melody 1
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 0
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 64) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 1
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 65) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 2
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 66) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 3
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 67) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 4
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 68) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 5
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 3, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 69) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 6
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 70) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 }, // Copy of measure 7
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 71) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        // Pattern 44 (in the FL Studio file)
        new NoteEvent { time = (BARS_TO_SECONDS * 72) + (BEATS_TO_SECONDS) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 72) + (BEATS_TO_SECONDS) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 72) + (BEATS_TO_SECONDS) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 72) + (BEATS_TO_SECONDS) * 3, lane = 2 },
        
        // Pattern 83
        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 73) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 73) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 73) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 73) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 74) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 74) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 74) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 74) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 75) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 75) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 75) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 75) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 76) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 76) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 76) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 76) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 77) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 77) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 77) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 77) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 78) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 78) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 78) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 78) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 79) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 79) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 79) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 79) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 80) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 80) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 80) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 80) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 81) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 81) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 81) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 81) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 82) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 82) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 82) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 82) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 83) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 83) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 83) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 83) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 84) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 84) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 84) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 84) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 85) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 85) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 85) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 85) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 86) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 86) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 86) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 86) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 87) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 87) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 87) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 87) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 88) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 88) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 88) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 88) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        // Pattern 49
        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 2, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 89) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 0, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 1, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 90) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 1, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 4, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 91) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 0, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 92) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 2, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 93) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 0, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 1, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 4, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 94) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 1, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 4, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 95) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 0, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 2, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 96) + (BEATS_TO_SECONDS / 2) * 6, lane = 0 },

        // Pattern 85
        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 97) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 98) + (BEATS_TO_SECONDS / 2) * 7, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 99) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 100) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        // Block
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 101) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 102) + (BEATS_TO_SECONDS / 2) * 7, lane = 2 },

        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 103) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 1, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 3, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 5, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 6, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 104) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },

        // End of song
        new NoteEvent { time = (BARS_TO_SECONDS * 105) + (BEATS_TO_SECONDS) * 0, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 105) + (BEATS_TO_SECONDS) * 1, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 105) + (BEATS_TO_SECONDS) * 2, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 105) + (BEATS_TO_SECONDS) * 3, lane = 3 },

    };

    private void Start()
    {
        foreach(NoteEvent note in chart)
        {
            levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
            {
                time = note.time - 2.2f, // - (BARS_TO_SECONDS * n) -> To start the spawning at a certain point
                action = () => SpawnNote(note)
            });
        }
    }

    void SpawnNote(NoteEvent noteEvent)
    {
        GameObject prefab = lanePrefabs[noteEvent.lane];
        Transform spawnPoint = laneSpawnPoints[noteEvent.lane];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
