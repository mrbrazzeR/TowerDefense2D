using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject load;
    // Start is called before the first frame update
    public void start(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }
    public void quit()
    {
        Application.Quit();
    }
    private void Start()
    {
        Screen.SetResolution(1560,720, FullScreenMode.ExclusiveFullScreen, 60);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
