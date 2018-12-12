using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour {
    public Slider volumeSlider;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("volume level") == true)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume level");
        }
        else
        {
            volumeSlider.value = 0.5f;
        }
            

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume level", volumeSlider.value);
    }
}
