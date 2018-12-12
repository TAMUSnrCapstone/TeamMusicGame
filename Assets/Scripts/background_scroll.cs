using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_scroll : MonoBehaviour {

	private static int movespeed = 1;
	private Vector3 userDirection = Vector3.left;
	public bool isMoving;
	bool replaced_myself;

	// Use this for initialization
	void Start () {
		isMoving = true;
		replaced_myself = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving) {
			transform.Translate (userDirection * movespeed * Time.deltaTime);
		} 

		if (gameObject.transform.position.x < -7.0f && replaced_myself == false) {
			GameObject new_self = GameObject.Instantiate (this.gameObject);
			new_self.transform.position = new Vector3 (this.transform.position.x+32f, this.transform.position.y, 0);
			replaced_myself = true;
		}
		if (gameObject.transform.position.x < -40f) {
			Destroy (this.gameObject);
		}
	}
}
