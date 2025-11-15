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
    };

    private void Start()
    {
        foreach(NoteEvent note in chart)
        {
            levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
            {
                time = note.time - 2.2f,
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
