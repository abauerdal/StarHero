using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    private GameObject _dynamic;

    [SerializeField]
    private AudioSource soundObject;

    private void Awake()
    {
        if (instance == null)
        {
            _dynamic = GameObject.Find("_Dynamic");
            instance = this;
        }
    }

    // Play a sound at a specific position in the world
    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {

        AudioSource audioSource = Instantiate(soundObject, new Vector3(), Quaternion.identity, _dynamic.transform);

        audioSource.clip = clip; // Set the specified clip you want to play

        audioSource.volume = volume; // Set its volume

        audioSource.Play();

        // Destroy the audio source after the clip has finished playing
        float clipLength = clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
