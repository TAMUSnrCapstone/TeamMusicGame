using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPoint : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Time.timeScale = 0f;
        if (coll.gameObject.tag == "Note")
        {
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

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
