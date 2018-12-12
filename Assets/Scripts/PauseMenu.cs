using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseUI;
    public GameObject winUI;
    public GameObject loseUI;

    void Start()
    {
      pauseUI.SetActive(false);
    }

    void Update()
    {
		if(Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Space))
        {
            if(isPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
     }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void SaveGame()
    {
        SaveLoad.Save();
        print("Saving progress...");
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadLevelSelect()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("level select");
    }

    public void LoadLevelSelectWin()
    {
        winUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("level select");
    }
    public void LoadLevelSelectLose()
    {
        loseUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("level select");
    }

}
