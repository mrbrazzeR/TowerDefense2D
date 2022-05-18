using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject endGameMenu;
    // Start is called before the first frame update
    public void Home(int SceneID)
    {
        GameStats.stats = "resume";
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }
    public void Restart(int SceneID)
    {
        GameStats.stats = "resume";
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }
}
