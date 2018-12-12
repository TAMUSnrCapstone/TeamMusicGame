using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeMaster : MonoBehaviour {

    private static volumeMaster original;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (original == null)
        {
            original = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("volume level") == true)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volume level");
        }
        else
        {
            AudioListener.volume = 0.5f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
