using UnityEngine;

public class PlayerScrape : MonoBehaviour
{
    public Player player;
    public int pointsPerScrape = 1;
    public float scrapeInterval = 0.1f; 

    private float scrapeTimer = 0f;

    private void Update()
    {
        scrapeTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("hostile"))
        {
            // only gain whammy if not hit and timer ready
            if (!player.wasHitThisFrame && scrapeTimer <= 0f)
            {
                player.AddScrapePoints(pointsPerScrape);
                scrapeTimer = scrapeInterval;
            }
        }
    }
}
