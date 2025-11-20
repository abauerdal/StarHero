using Unity.VisualScripting;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject levelEndMenu;
    public LevelEventsHandler levelEventsHandler;
    public LevelLoader levelLoader;
    public AudioClip pauseSound;
    public AudioClip victorySound;
    public Player player;
    public Enemy enemy;

    public bool gameOverTriggered = false;
    public bool pauseMenuOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverTriggered)
        {
            OpenPauseMenu();
        }
    }

    public void TriggerGameOver()
    {
        gameOverTriggered = true;
        levelEventsHandler.Pause();
        Invoke("OpenGameOverMenu", 3f);
    }

    public void TriggerLevelEnd()
    {
        gameOverTriggered = true;
        DeleteAllPlayerBullets();
        levelEventsHandler.Pause();
        Invoke("OpenLevelEndMenu", 5f);
    }

    public void OpenLevelEndMenu()
    {
        SFXManager.instance.PlaySound(victorySound, 0.5f);
        levelEndMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        gameOverTriggered = false;
        gameOverMenu.SetActive(false);
        ResumeGame();
        levelEventsHandler.Restart();
        player.ResetPlayer();
        enemy.ResetEnemy();
    }

    public void OpenGameOverMenu()
    {
        SFXManager.instance.PlaySound(pauseSound, 0.5f);
        gameOverMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenuOpen = false;
        ResumeGame();
        pauseMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        if (!pauseMenuOpen) {
            pauseMenuOpen = true;
            PauseGame();
            SFXManager.instance.PlaySound(pauseSound, 0.5f);
            pauseMenu.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        levelEventsHandler.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        levelEventsHandler.Resume();
    }

    public void BackToMainMenu()
    {
        levelLoader.LoadLevel("LevelSelectScene");
    }

    private void DeleteAllPlayerBullets()
    {
        GameObject[] playerBullets = GameObject.FindGameObjectsWithTag("Player_bullet");

        // Iterate through the array and destroy each GameObject
        foreach (GameObject pb in playerBullets)
        {
            Destroy(pb);
        }
    }
}
