using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartPoint : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Note"){
            BossMoveScript eMoveScript = coll.gameObject.GetComponent<BossMoveScript>();
            eMoveScript.BossIsInThreshold = true;
        }
    }

	private void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Note"){
			BossMoveScript eMoveScript = coll.gameObject.GetComponent<BossMoveScript>();
			eMoveScript.BossIsInThreshold = true;
		}
	}

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
