using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Text scoreText4;

    // Use this for initialization
    void Start () {
		if(PlayerPrefs.HasKey("SampleScenescore") == true)
        {
            scoreText1.text = "High Score: " + ((int)PlayerPrefs.GetFloat("SampleScenescore")).ToString();
        }
        else
        {
            scoreText1.text = "High Score: 0";
        }
        if (PlayerPrefs.HasKey("SampleScene2score") == true)
        {
            scoreText2.text = "High Score: " + ((int)PlayerPrefs.GetFloat("SampleScene2score")).ToString();
        }
        else
        {
            scoreText2.text = "High Score: 0";
        }
        if (PlayerPrefs.HasKey("BossScenescore") == true)
        {
            scoreText3.text = "High Score: " + ((int)PlayerPrefs.GetFloat("BossScenescore")).ToString();
        }
        else
        {
            scoreText3.text = "High Score: 0";
        }
        if (PlayerPrefs.HasKey("SampleScene3score") == true)
        {
            scoreText4.text = "High Score: " + ((int)PlayerPrefs.GetFloat("SampleScene3score")).ToString();
        }
        else
        {
            scoreText4.text = "High Score: 0";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
