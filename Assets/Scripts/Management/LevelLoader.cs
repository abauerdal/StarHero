using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Load the specified level by name
    public void LoadLevel(string levelName)
    {
        if(levelName == "SampleScene")
        {

            var menuMusic = GameObject.Find("MenuMusic");
            if(menuMusic != null)
            {
                GameObject.Destroy(menuMusic);
            }
        }
        SceneManager.LoadScene(levelName);
    }
}
