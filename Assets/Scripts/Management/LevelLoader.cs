using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Load the specified level by name
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
