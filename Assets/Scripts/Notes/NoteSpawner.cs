using UnityEngine;

public class NoteEvent
{
    public float time;
    public int lane;
}

public class NoteSpawner : MonoBehaviour
{
    public GameObject normalNotePrefab;
    public GameObject[] lanePrefabs = new GameObject[4];
    public Transform[] laneSpawnPoints;
    public float noteSpeed = 5f;

    public NoteEvent[] chart = new NoteEvent[]
    {
        new NoteEvent { time = 1.0f, lane = 3 },
        new NoteEvent { time = 1.2f, lane = 0 },
        new NoteEvent { time = 1.5f, lane = 1 },
        new NoteEvent { time = 1.8f, lane = 2 },
        new NoteEvent { time = 2.5f, lane = 3 },
        new NoteEvent { time = 2.7f, lane = 0 },
        new NoteEvent { time = 3.0f, lane = 1 },
        new NoteEvent { time = 3.2f, lane = 2 },
    };

    private int nextNoteIndex = 0;

    void Update()
    {
        if (nextNoteIndex < chart.Length && Time.time >= chart[nextNoteIndex].time)
        {
            SpawnNote(chart[nextNoteIndex]);
            nextNoteIndex++;
        }
    }

    void SpawnNote(NoteEvent noteEvent)
    {
        GameObject prefab = lanePrefabs[noteEvent.lane];
        Note noteScript = prefab.GetComponent<Note>();
        noteScript.SetSpeed(noteSpeed);

        Transform spawnPoint = laneSpawnPoints[noteEvent.lane];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
