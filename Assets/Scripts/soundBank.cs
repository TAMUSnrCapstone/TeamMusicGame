using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBank : MonoBehaviour {
	// arraylist containing the sound samples
	public List<AudioClip> clips;
	// list of components that actually play the sounds
	public List<AudioSource> sources;

	//integer value of note to determine what sample to play
	public void playSample(int note) {
        // TODO: note-60 is a temporary adjustment until all the samples have been added. 
        try
        {
			// since sources contains all of the samples in order, we can index them 
			// note: the -24 adjusts for us missing 24 samples
			// TODO: range checking and transposition for notes outside our piano's range
			sources[note-24].Play();
        }
		// eventually this won't be needed
        catch (System.ArgumentOutOfRangeException ex)
        {
            print("Error: " + note.ToString() + " out of bounds.");
        }
	}

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(transform.gameObject);
        // we make an audiosource instance for each sample
        sources = new List<AudioSource>();
		for (int i = 0; i < 59; ++i) {
			// load each audiosource with its sample
			AudioSource src = gameObject.AddComponent<AudioSource> ();
			src.clip = clips [i];
			// then append it to sources so we can reference it in playSample()
			sources.Add (src);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
