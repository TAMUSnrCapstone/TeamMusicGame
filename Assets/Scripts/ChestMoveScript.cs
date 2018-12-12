using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class ChestMoveScript : MonoBehaviour
{

    Vector3 origin;

    private static int movespeed = 1;
    public int assignedKey;
    private Vector3 userDirection = Vector3.left;
    public bool isMoving;
    public bool isInThreshold;
    public float pointValue = 300f;

    // Use this for initialization
    void Start()
    {
        isMoving = true;
        isInThreshold = false;

    }

	// Update is called once per frame
	void Update () {

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
				if (pointValue > 100.1) {
					pointValue = pointValue - 0.1f;
				}
			}
		}

	}
}