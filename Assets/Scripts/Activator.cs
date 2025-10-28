using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key; // Key to press for the activator
    public Player player;
    bool active = false; // Whether the activator is in range of a note
    GameObject note; // Reference to the note in range

    void Update()
    {
        if (active && Input.GetKey(key) && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(note);
            Debug.Log("Note hit!");

            //call player to fire
            player.Shoot();

        }

        if (!active && Input.GetKey(key) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("no note to play!");
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            active = true;
            note = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            active = false;
            note = null;
        }
    }
}