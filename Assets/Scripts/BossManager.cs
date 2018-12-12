using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;

public class BossManager : MonoBehaviour {

    public GameObject[] notes;
    public Queue<GameObject> currentNotes = new Queue<GameObject>();

    public GameObject[] monsters;
    //public Queue<GameObject> currentMonster = new Queue<GameObject>();
    public List<string> noteNames;

    public int noteCount = 0;

    public GameObject kb;

    public float spawnTime = 1f;
    public Transform spawnPoint;
    public float score = 0f;


    public Text scoreText;
    public Text coinText;
    public Text AmbrosiaText;
    public Text FleeceText;
    public Text SandalText;
    public Text statusText;
    public Text noteText;

    private Vector3 notespos;
    private Quaternion notesrot;
    private Vector3 monsterPos;
    private Quaternion monsterRot;

    private GameObject staff;

    public int limit;
    public int enemyCount;// how many enemies have been deleted
    public int threshold;//difficulty threshold for the level
    public int threshLimit;
    public int streak;
    public int bad_hit; //how many times a bad note has ben hit

    public GameObject winUI;
    public GameObject loseUI;

    public int AmbrosiaCount;
    public int FleeceCount;
    public int SandalCount;

    public bool fleeceActive = false;//is the fleece active?
    public bool sandalActive = false;//is the not active?

    private progress_bar top_bar;

    public bool inBossScene = false;

    void Awake()
    {

    }


    // Use this for initialization
    void Start() {
        // use this to interface with the top bar by calling top_bar.setPercentage(float percentage);
        top_bar = GameObject.FindGameObjectWithTag("progress_bar").GetComponent<progress_bar>();
        staff = GameObject.Find("grand staff");
        limit = 0;
        enemyCount = 0;
        threshold = 1;
        streak = 0;
        bad_hit = 0;

        inBossScene = true;

        Vector3 staffPos = staff.transform.position;
        float staffPosX = staffPos.x;
        float staffPosY = staffPos.y;
        float staffSizeX = staff.GetComponent<SpriteRenderer>().size.x;
        float staffSizeY = staff.GetComponent<SpriteRenderer>().size.y;

        notespos.Set(20f, staffPosY, 0);
        //notespos.Set(staffPosX + staffSizeX/2, staffPosY, 0);
        notesrot.Set(0, 0, 0, 1);
        monsterPos.Set(20f, 5.5f, 0);
        monsterRot.Set(0, 0, 0, 1);

        initNoteNames();

        setSavedValues();

        winUI.SetActive(false);
        loseUI.SetActive(false);

        statusText.text = "";

        UpdateUI();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn() {
        if (limit < 8) {
            //int i = Random.Range(0, 2 * threshold);
            print("Note Count >> " + noteCount);
            notes[noteCount].transform.localScale = staff.transform.localScale;
            currentNotes.Enqueue(Instantiate(notes[noteCount], notespos, notesrot));
            noteCount++;

            //currentMonster.Enqueue(Instantiate(monsters[noteCount], monsterPos, monsterRot));
            limit++;
        }
    }

    void initNoteNames()
    {
        noteNames = new List<string>() {  "A0", "A#0", "B0", "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0",
                                           "A1", "A#1", "B1", "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1",
                                           "A2", "A#2", "B2", "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2",
                                           "A3", "A#3", "B3", "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3",
                                           "A4", "A#4", "B4", "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4",
                                           "A5", "A#5", "B5", "C5", "C#5", "D5", "D#5", "E5", "F5", "F#5", "G5", "G#5",
                                           "A6", "A#6", "B6", "C6", "C#6", "D6", "D#6", "E6", "F6", "F#6", "G6", "G#6",
                                           "A7", "A#7", "B7", "C7"};
    }

    public void KeyPress(int key) {//called when a key has been pressed

        if (limit > 0)
        {
            GameObject firstNote = currentNotes.Peek();
            BossMoveScript ems = firstNote.GetComponent<BossMoveScript>();
            if (ems.BossIsInThreshold == true && ems.assignedKey == key) {
                streak++;
                GameObject toBeDeleted = currentNotes.Dequeue();//dequeue first in queue

                foreach (GameObject ge in currentNotes)
                {
                    BossMoveScript eMoveScript = ge.GetComponent<BossMoveScript>();
                    eMoveScript.BossIsMoving = true;
                }
                Destroy(toBeDeleted);
                limit--;

                //toBeDeleted = currentMonster.Dequeue();//dequeue first in queue

                // sprite exploder stuff
                try {
                    // trigger the explosion
                    toBeDeleted.GetComponent<SpriteExploder>().ExplodeSprite();
                    // unparent the explosion object so it doesn't get deleted below
                    Transform explosion = toBeDeleted.transform.Find("ExplosionPixels");
                    explosion.transform.parent = null;
                }
                // for all the enemies who don't explode yet
                catch (System.Exception ex) {
                    print("Error: I probably don't have a sprite exploder.");
                    print(ex.Message);
                }

                IncreaseScore(toBeDeleted);//increment the score
                UpdateUI();
                top_bar.setPercentage(score / 2400f);

                /*foreach (GameObject ge in currentMonster)
                {
                    BossMoveScript eMoveScript = ge.GetComponent<BossMoveScript>();
                    eMoveScript.BossIsMoving = true;
                }
                Destroy(toBeDeleted);*/
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("background")) {
                    go.GetComponent<background_scroll>().isMoving = true;
                }
                IncreaseEnemyCount();
                if (!IsInvoking("Spawn")) {
                    InvokeRepeating("Spawn", 1, spawnTime);
                }
                if ((streak % 10) == 0 && streak != 0)
                {
                    IncreaseThreshold();
                }
            } else {
                streak = 0;
                bad_hit++;
                if (bad_hit >= 3)
                {
                    if (AmbrosiaCount >= 1)
                    {
                        AmbrosiaCount--;
                        statusText.text = "Ambrosia Activated ";
                        UpdateUI();
                        bad_hit = 0;
                    }
                    else
                    {
                        DecreaseThreshold();
                    }

                }
            }

        }

        noteText.text = "Last note pressed: " + noteNames[key - 21];
    }

    // Update is called once per frame
    void Update() {

    }

    public void CancelSpawn() {
        CancelInvoke("Spawn");
    }

    void UpdateUI()
    {
        scoreText.text = ((int)score).ToString();
        coinText.text = "Beat Coins: " + PlayerPrefs.GetInt("BeatCoins").ToString();
        AmbrosiaText.text = "Ambrosia: " + AmbrosiaCount.ToString();
        FleeceText.text = "Golden Fleece: " + FleeceCount.ToString();
        SandalText.text = "Sandals: " + SandalCount.ToString();
    }

    void IncreaseEnemyCount()// increments and checks how many enemies have been defeated this level
    {
        enemyCount++;
        if (enemyCount == 64)
        {
            CheckScore();
        }
    }

    void CheckScore() // checks the score for the level. Basic now, but it will improve
    {
        if (score >= 5400f)
        {
            winUI.SetActive(true);
            string level_score = SceneManager.GetActiveScene().name + "score";
            PlayerPrefs.SetFloat(level_score, score);
            calculateCurrency();
            SaveValues();

            Time.timeScale = 0f;
        }
        else
        {
            loseUI.SetActive(true);
            SaveValues();
            Time.timeScale = 0f;
        }
    }

    void calculateCurrency()
    {
        if (PlayerPrefs.HasKey("BeatCoins") == true)
        {
            int oldCurrency = PlayerPrefs.GetInt("BeatCoins");
            int addedValue = (int)score / 100;
            int newCurrency = oldCurrency + addedValue;
            PlayerPrefs.SetInt("BeatCoins", newCurrency);
        }
        else
        {
            PlayerPrefs.SetInt("BeatCoins", 0);
        }
    }

    void setSavedValues()
    {
        string pref_name = SceneManager.GetActiveScene().name + " threshold";
        if (PlayerPrefs.HasKey(pref_name) == true)
        {
            threshold = PlayerPrefs.GetInt(pref_name);
        }
        else
        {
            threshold = 1;
        }

        if (PlayerPrefs.HasKey("Ambrosia") == true)
        {
            AmbrosiaCount = PlayerPrefs.GetInt("Ambrosia");
        }
        else
        {
            AmbrosiaCount = 0;
        }

        if (PlayerPrefs.HasKey("Golden Fleece") == true)
        {
            FleeceCount = PlayerPrefs.GetInt("Golden Fleece");
        }
        else
        {
            FleeceCount = 0;
        }

        if (PlayerPrefs.HasKey("Hermes Sandals") == true)
        {
            SandalCount = PlayerPrefs.GetInt("Hermes Sandals");
        }
        else
        {
            SandalCount = 0;
        }
    }

    void SaveValues()
    {
        PlayerPrefs.SetInt("Ambrosia", AmbrosiaCount);
        PlayerPrefs.SetInt("Golden Fleece", FleeceCount);
        PlayerPrefs.SetInt("Hermes Sandals", SandalCount);
    }

    void IncreaseScore(GameObject ge)
    {
        float modifier = 1f;
        if(sandalActive == true)
        {
            modifier = 2f;
        }
        BossMoveScript ems = ge.GetComponent<BossMoveScript>();
        score = score + (ems.pointValue * modifier);
    }

	void IncreaseThreshold(){//set threshold
		if (threshold < threshLimit) {
			threshold++;


            string pref_name = SceneManager.GetActiveScene().name + " threshold";
            PlayerPrefs.SetInt(pref_name, threshold);
            print("Saving progress...\n");

        }
	}

	void DecreaseThreshold(){//set threshold
		if (threshold > 1) {

			threshold--;
            bad_hit = 0;

            string pref_name = SceneManager.GetActiveScene().name + " threshold";
            PlayerPrefs.SetInt(pref_name, threshold);
            print("Saving progress...\n");

        }
    }

    void SandalActivate()
    {
        if (sandalActive == false)
        {
            sandalActive = true;
            statusText.text = "Hermes' Sandals Activated ";
        }
        else
        {
            sandalActive = false;
            statusText.text = "Hermes' Sandals Deactivated ";
            CancelInvoke("SandalActivate");
        }
    }


    public void SandalButtonHit()
    {
        if(!winUI.activeInHierarchy && !loseUI.activeInHierarchy)
        {
            if (SandalCount >= 1)
            {
                SandalCount--;
                UpdateUI();
                InvokeRepeating("SandalActivate", 0, 10);
            }
            else
            {
                statusText.text = "You have no Hermes' Sandals!";
            }
        }



    }

    void FleeceActivate()
    {
        if (fleeceActive == false)
        {
            fleeceActive = true;

            statusText.text = "Golden Fleece Activated ";
        }
        else
        {
            fleeceActive = false;
            statusText.text = "Golden Fleece Deactivated ";
            CancelInvoke("FleeceActivate");
        }
    }


    public void FleeceButtonHit()
    {
        if (!winUI.activeInHierarchy && !loseUI.activeInHierarchy)
        {
            if (FleeceCount >= 1)
            {
                FleeceCount--;
                UpdateUI();
                InvokeRepeating("FleeceActivate", 0, 10);
            }
            else
            {
                statusText.text = "You have no Golden Fleece!";
            }
        }
    }


}
