using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class EnemyMoveScript : MonoBehaviour {

    Vector3 origin;

    private static int movespeed = 3;
    public int assignedKey;
    private Vector3 userDirection = Vector3.left;
    public bool isMoving;
    public bool isInThreshold;
    public bool isAChord;
	public float pointValue = 100f;

    // Use this for initialization
	void Start () {
        isMoving = true;
        isInThreshold = false;
        isAChord = false;
    }
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Space)) {
//			gameObject.GetComponent<SpriteExploder> ().ExplodeSprite ();
//		}

		if (isMoving) {
			transform.Translate (userDirection * movespeed * Time.deltaTime);
			if (this.transform.position.x <= -0.5f) {
				isInThreshold = true;
			}
			if (this.transform.position.x <= -1.5f) {
				GameObject eManager = GameObject.Find("EnemyManager");
				EnemyManager eManScript = eManager.GetComponent<EnemyManager>();
				eManScript.CancelSpawn();
				foreach (GameObject ge in eManScript.currentNotes)
				{
					EnemyMoveScript eMoveScript = ge.GetComponent<EnemyMoveScript>();
					eMoveScript.isMoving = false;
				}
				foreach (GameObject ge in eManScript.currentMonster)
				{
					EnemyMoveScript eMoveScript = ge.GetComponent<EnemyMoveScript>();
					eMoveScript.isMoving = false;
				}
				foreach (GameObject go in GameObject.FindGameObjectsWithTag ("background")) {
					go.GetComponent<background_scroll> ().isMoving = false;
				}
			}
				
		} else {
			if (isInThreshold) {
                GameObject eManager = GameObject.Find("EnemyManager");
                EnemyManager eManScript = eManager.GetComponent<EnemyManager>();
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
