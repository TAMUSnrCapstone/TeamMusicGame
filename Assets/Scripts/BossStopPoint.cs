using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStopPoint : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Time.timeScale = 0f;
        if (coll.gameObject.tag == "Note")
        {
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

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
