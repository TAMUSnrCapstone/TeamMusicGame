using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Control : MonoBehaviour {

    void Start()
    {
        if (PlayerPrefs.HasKey("BeatCoins") == false)
        {
            PlayerPrefs.SetInt("BeatCoins", 0);
        }
    }

    public void LoadMainMenu()
    {
      GameObject ge = GameObject.Find("Keyboard");
      GameObject go = GameObject.Find("TriggeredSoundBanks");
      	GameObject bgm = GameObject.Find ("BackgroundMusic");
      GameObject.DontDestroyOnLoad(ge);
      GameObject.DontDestroyOnLoad(go);
      GameObject.DontDestroyOnLoad (bgm);
        SceneManager.LoadScene("Main menu");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("SampleScene3");
    }

    public void LoadBossScene()
    {
        SceneManager.LoadScene("BossScene");
    }

    public void LoadLevelSelect()
    {
        GameObject ge = GameObject.Find("Keyboard");
		GameObject go = GameObject.Find("TriggeredSoundBanks");
		GameObject bgm = GameObject.Find ("BackgroundMusic");
        GameObject.DontDestroyOnLoad(ge);
		GameObject.DontDestroyOnLoad(go);
		GameObject.DontDestroyOnLoad (bgm);
        SceneManager.LoadScene("level select");
    }

    public void LoadTutorial()
    {
      GameObject ge = GameObject.Find("Keyboard");
      GameObject go = GameObject.Find("TriggeredSoundBanks");
      	GameObject bgm = GameObject.Find ("BackgroundMusic");
      GameObject.DontDestroyOnLoad(ge);
      GameObject.DontDestroyOnLoad(go);
      GameObject.DontDestroyOnLoad (bgm);
      SceneManager.LoadScene("Tutorial");
    }

    public void LoadTutorialLevel()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
      GameObject ge = GameObject.Find("Keyboard");
      GameObject go = GameObject.Find("TriggeredSoundBanks");
      	GameObject bgm = GameObject.Find ("BackgroundMusic");
      GameObject.DontDestroyOnLoad(ge);
      GameObject.DontDestroyOnLoad(go);
      GameObject.DontDestroyOnLoad (bgm);
        SceneManager.LoadScene("CreditsScreen");
    }

    public void LoadSettings()
    {
      GameObject ge = GameObject.Find("Keyboard");
      GameObject go = GameObject.Find("TriggeredSoundBanks");
      	GameObject bgm = GameObject.Find ("BackgroundMusic");
      GameObject.DontDestroyOnLoad(ge);
      GameObject.DontDestroyOnLoad(go);
      GameObject.DontDestroyOnLoad (bgm);
        SceneManager.LoadScene("SettingsScreen");
    }

    public void LoadShop()
    {
      GameObject ge = GameObject.Find("Keyboard");
      GameObject go = GameObject.Find("TriggeredSoundBanks");
      	GameObject bgm = GameObject.Find ("BackgroundMusic");
      GameObject.DontDestroyOnLoad(ge);
      GameObject.DontDestroyOnLoad(go);
      GameObject.DontDestroyOnLoad (bgm);
        SceneManager.LoadScene("ItemShop");
    }

}
