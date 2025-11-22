using UnityEngine;
using UnityEngine.UI;

public class NoteInformationHandler : MonoBehaviour
{
    public static NoteInformationHandler instance;

    private int missedNotes = 0;
    private int successfulHits = 0;
    private int hitNothing = 0;

    public Slider healthDebtSlider;

    private void Start()
    {
        healthDebtSlider.maxValue = NoteSpawner.totalNotes;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void AddMissedNote()
    {
        missedNotes++;
        UpdateHealthDebt();
    }
    public void AddSuccessfulHit()
    {
        successfulHits++;
    }
    public void AddHitNothing()
    {
        hitNothing++;
        UpdateHealthDebt();
    }

    private void UpdateHealthDebt()
    {
        healthDebtSlider.maxValue = NoteSpawner.totalNotes;
        healthDebtSlider.value = missedNotes + hitNothing;
    }

    public void ResetNoteInformation()
    {
        missedNotes = 0;
        successfulHits = 0;
        hitNothing = 0;
        UpdateHealthDebt();
    }
}
