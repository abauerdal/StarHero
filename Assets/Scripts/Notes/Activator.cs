using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key; // Key to press for the activator
    public Player player;

    [Header("Bullet Attributes")]
    public Color bulletColor;
    public Sprite bulletSprite;

    // Regular notes
    bool activeRegularNote = false; // Whether the activator is in range of a note
    private Note regularNote; // Reference to the note in range

    // Hold notes
    private bool inStartZone = false;
    private bool inEndZone = false;
    private HoldNote holdNote;


    void Update()
    {
        if (LevelHandler.instance.gameOverTriggered) { return; }
        if (Input.GetKeyDown(key))
        {
            // Regular note press
            if (activeRegularNote)
            {
                regularNote.Hit();
                Destroy(regularNote.gameObject);
                Debug.Log("Note hit!");
                NoteInformationHandler.instance.AddSuccessfulHit();
                player.Shoot(bulletColor, bulletSprite);
            }
            // Hold note press
            else if (inStartZone && !holdNote.pressed)
            {
                holdNote.pressed = true;
                Debug.Log("Hold note started!");
            }
            // No note
            else
            {
                Debug.Log("No note to hit!");
                NoteInformationHandler.instance.AddHitNothing();
            }
        }

        // Hold note release
        if (Input.GetKeyUp(key))
        {
            if (inEndZone && holdNote != null && holdNote.pressed)
            {
                holdNote.completed = true;
                Debug.Log("Hold note completed!");
                Destroy(holdNote.gameObject);
                player.Shoot(bulletColor, bulletSprite); // Big laser later?
                holdNote = null;
            }
            else if (holdNote != null && holdNote.pressed)
            {
                Debug.Log("Hold released too early/late!");
                holdNote = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            activeRegularNote = true;
            regularNote = col.GetComponent<Note>();
        }
        else if (col.CompareTag("HoldStart"))
        {
            inStartZone = true;
            holdNote = col.transform.parent.GetComponent<HoldNote>();
        }
        else if (col.CompareTag("HoldEnd"))
        {
            inEndZone = true;
            holdNote = col.transform.parent.GetComponent<HoldNote>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            if (col.GetComponent<Note>() == regularNote)
            {
                activeRegularNote = false;
                regularNote = null;
                if (!col.GetComponent<Note>().getWasHit())
                {
                    NoteInformationHandler.instance.AddMissedNote();
                }
            }
        }
        else if (col.CompareTag("HoldStart"))
        {
            inStartZone = false;
        }
        else if (col.CompareTag("HoldEnd"))
        {
            inEndZone = false;
        }
    }
}