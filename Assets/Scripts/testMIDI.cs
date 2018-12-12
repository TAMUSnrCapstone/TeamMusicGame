using UnityEngine;
using System.Collections;
using MidiJack;
using UnityEngine.SceneManagement;

public class testMIDI : MonoBehaviour
{

	private soundBank sb;
    public int currentKey;
    public Color initialColor;

    public Sprite unpressed;
    public Sprite pressed;

	// Use this for initialization
	void Start () {

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = initialColor;

		// TODO: give triggeredSounds its own tag
		// since we need GameController for other things.
		sb = GameObject.FindGameObjectWithTag ("GameController").GetComponent<soundBank>();
        this.transform.localScale = new Vector3(2, 2, 1);
	}

	private void FixedUpdate()
	{
        Time.fixedDeltaTime = 1;
	}

	// Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name != "SampleScene" && SceneManager.GetActiveScene().name != "SampleScene2" && SceneManager.GetActiveScene().name != "BossScene" && SceneManager.GetActiveScene().name != "SampleScene3" && SceneManager.GetActiveScene().name != "TutorialScene")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        /*
        // for testing
        if (Input.GetKey("c")) {

            //play the corresponding sample
            sb.playSample(currentKey);

            sprite.color = Color.green;
            sprite.sprite = pressed;

        }
        else {
            sprite.color = initialColor;
            sprite.sprite = unpressed;
        }
        */   
		// returns true when the key is pressed
        if(MidiMaster.GetKeyDown(currentKey)){

            // make the key large
            //this.transform.localScale = new Vector3(3, 3, 1);
            sprite.color = Color.green;
            sprite.sprite = pressed;

            //play the corresponding sample
            sb.playSample(currentKey);
            // print("Current key: " + currentKey);

            GameObject bossManager;
            GameObject eManager;

            if (bossManager=GameObject.Find("BossManager")){
                BossManager bossManScript = bossManager.GetComponent<BossManager>();
                bossManScript.KeyPress(currentKey);
            }
            else {
                eManager = GameObject.Find("EnemyManager");
                EnemyManager eManScript = eManager.GetComponent<EnemyManager>();
                eManScript.KeyPress(currentKey);
            }

            
        }
        // returns true when the key is released
        else if (MidiMaster.GetKeyUp(currentKey)){

			//return to normal size.
            //this.transform.localScale = new Vector3(2, 2, 1);
            sprite.color = initialColor;
            sprite.sprite = unpressed;
        }
        //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(currentKey));
}
}