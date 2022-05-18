using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    public void Pause()
    {
        GameStats.stats = "pause";
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GameStats.stats = "resume";
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int SceneID)
    {
        GameStats.stats = "resume";
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }
    public void Restart(int SceneID)
    {
        GameStats.stats = "resume";
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneID);
    }
}
