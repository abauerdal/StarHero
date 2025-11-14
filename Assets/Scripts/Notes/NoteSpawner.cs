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
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 4, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 5, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 6, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 0) + (BEATS_TO_SECONDS / 2) * 7, lane = 1 },

        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 0, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 1, lane = 0 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 2, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 3, lane = 1 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 4, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 5, lane = 2 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 6, lane = 3 },
        new NoteEvent { time = (BARS_TO_SECONDS * 1) + (BEATS_TO_SECONDS / 2) * 7, lane = 3 },
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
