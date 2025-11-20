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

    public NoteEvent[] chart = Level1Notes.chart;

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
