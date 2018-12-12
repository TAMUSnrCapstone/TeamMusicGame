using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress_bar : MonoBehaviour {

	private float normalize(float f) {
		return f * 0.93f;
	}

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (0.0f, 1.0f, 1.0f);
	}

	public void setPercentage(float p) {
		if (p > 1.0f) {
			gameObject.transform.localScale = new Vector3 (0.93f, 1.0f, 1.0f);
		} else if (p < 0.0f) {
			gameObject.transform.localScale = new Vector3 (0.0f, 1.0f, 1.0f);
		} else {
			gameObject.transform.localScale = new Vector3 (normalize(p), 1.0f, 1.0f);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
