using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class BossMoveScript : MonoBehaviour {

    Vector3 origin;

    private static int movespeed = 5;
    public int assignedKey;
    private Vector3 userDirection = Vector3.left;
    public bool BossIsMoving;
    public bool BossIsInThreshold;
	public float pointValue = 100f;

    // Use this for initialization
	void Start () {
        BossIsMoving = true;
        BossIsInThreshold = false;

	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Space)) {
//			gameObject.GetComponent<SpriteExploder> ().ExplodeSprite ();
//		}

		if (BossIsMoving) {
			transform.Translate (userDirection * movespeed * Time.deltaTime);
			if (this.transform.position.x <= -0.5f) {
				BossIsInThreshold = true;
			}
			if (this.transform.position.x <= -1.5f) {
				GameObject eManager = GameObject.Find("BossManager");
				BossManager eManScript = eManager.GetComponent<BossManager>();
				eManScript.CancelSpawn();
				foreach (GameObject ge in eManScript.currentNotes)
				{
					BossMoveScript eMoveScript = ge.GetComponent<BossMoveScript>();
					eMoveScript.BossIsMoving = false;
				}
				/*foreach (GameObject ge in eManScript.currentMonster)
				{
					BossMoveScript eMoveScript = ge.GetComponent<BossMoveScript>();
					eMoveScript.BossIsMoving = false;
				}*/
				foreach (GameObject go in GameObject.FindGameObjectsWithTag ("background")) {
					go.GetComponent<background_scroll> ().isMoving = false;
				}
			}
				
		} else {
			if (BossIsInThreshold) {
                GameObject eManager = GameObject.Find("BossManager");
                BossManager eManScript = eManager.GetComponent<BossManager>();
                if (eManScript.fleeceActive == false)
                {
                    if (pointValue > 20.1)
                    {
                        pointValue = pointValue - 0.1f;
                    }
                }
                
			}
		}

	}
}
