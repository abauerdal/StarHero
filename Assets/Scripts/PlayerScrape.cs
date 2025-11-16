using UnityEngine;

public class PlayerScrape : MonoBehaviour
{
    public Player player;
    public int pointsPerScrape = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hostile"))
        {
            if (!player.IsInvincible())
            {
                player.AddScrapePoints(pointsPerScrape);
            }
        }
    }
}
