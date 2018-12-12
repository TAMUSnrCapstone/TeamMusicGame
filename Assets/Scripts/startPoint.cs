using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPoint : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Note"){
            EnemyMoveScript eMoveScript = coll.gameObject.GetComponent<EnemyMoveScript>();
            eMoveScript.isInThreshold = true;
        }
    }

	private void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Note"){
			EnemyMoveScript eMoveScript = coll.gameObject.GetComponent<EnemyMoveScript>();
			eMoveScript.isInThreshold = true;
		}
	}

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
