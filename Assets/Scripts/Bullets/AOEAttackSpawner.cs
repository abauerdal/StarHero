using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AOEAttackSpawner : MonoBehaviour
{
    public GameObject beamWarningPrefab;
    public GameObject beamAttackPrefab;
    public float warningDuration = 4.0f;
    public float attackDuration = 2f;
    public float direction; // Fixed rotation for the bullet
    
    private bool hasAttacked = false;
    double songTimeAtCreation;
    GameObject beamWarning;
    GameObject beamAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songTimeAtCreation = LevelEventsHandler.songTime;
        transform.rotation = Quaternion.Euler(0, 0, direction);

        beamWarning = Instantiate(beamWarningPrefab, new Vector3(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        double currentSongTime = LevelEventsHandler.songTime;

        if (currentSongTime >= songTimeAtCreation + warningDuration)
        {
            if (!hasAttacked) {
                beamAttack = Instantiate(beamAttackPrefab, new Vector3(), Quaternion.identity);
                Destroy(beamWarning);
                hasAttacked = true;
            }

            if (currentSongTime >= songTimeAtCreation + warningDuration + attackDuration)
            {
                Destroy(beamAttack);
                Destroy(gameObject);
                return;
            }
        }
    }
}
