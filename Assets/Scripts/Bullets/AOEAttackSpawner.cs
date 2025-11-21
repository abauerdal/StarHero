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
    public float width = 1f;
    
    private bool hasAttacked = false;
    double songTimeAtCreation;
    GameObject beamWarning;
    GameObject beamAttack;
    SpriteRenderer beamWarningSpriteRenderer;
    SpriteRenderer beamAttackSpriteRenderer;
    float beamWarningTransparency = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songTimeAtCreation = LevelEventsHandler.songTime;

        beamWarning = Instantiate(beamWarningPrefab, transform.position, Quaternion.Euler(0, 0, direction));
        beamWarningSpriteRenderer = beamWarning.GetComponent<SpriteRenderer>();
        beamWarningSpriteRenderer.size = new Vector2(beamWarningSpriteRenderer.size.x * width, beamWarningSpriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        double currentSongTime = LevelEventsHandler.songTime;

        if (currentSongTime >= songTimeAtCreation + warningDuration)
        {
            if (!hasAttacked) {
                beamAttack = Instantiate(beamAttackPrefab, transform.position, Quaternion.Euler(0, 0, direction));
                beamAttackSpriteRenderer = beamAttack.GetComponent<SpriteRenderer>();
                beamAttackSpriteRenderer.size = new Vector2((beamAttackSpriteRenderer.size.x * width) + 0.25f, beamAttackSpriteRenderer.size.y);

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
        else
        {
            double timeElapsed = currentSongTime - songTimeAtCreation;
            float ratioOfTimeLeftBeforeAttack = (float)(timeElapsed / warningDuration);

            float flashSpeed = Mathf.Lerp(0.5f, 10f, Mathf.Pow(ratioOfTimeLeftBeforeAttack, 2f));

            beamWarningTransparency = 0.1f + ((Mathf.Sin(Time.time * flashSpeed) + 1f) * 0.5f);

            beamWarningSpriteRenderer.color = new Color(1, 1, 1, beamWarningTransparency);

        }
    }
}
