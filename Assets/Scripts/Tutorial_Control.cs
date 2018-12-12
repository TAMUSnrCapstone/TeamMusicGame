using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Control : MonoBehaviour {

	private Image currentImage;

	private Button backbutton;
	private Button nextbutton;
	private Text descript;

	public List<Sprite> image;
	public List<string> descript_str;

	private int currentPage;

	public void NextPage() {

			if(currentPage < 10) {
				currentPage = currentPage + 1;
			}

			if(currentPage == 10) {
				nextbutton.enabled = false;
			}

			currentImage.sprite = image[currentPage];
			descript.text = descript_str[currentPage];
			backbutton.enabled = true;
	}

	public void BackPage() {

			if(currentPage != 0) {
				currentPage = currentPage - 1;
			}

			if(currentPage == 0) {
				backbutton.enabled = false;
			}

			currentImage.sprite = image[currentPage];
			descript.text = descript_str[currentPage];
			nextbutton.enabled = true;
	}

	// Use this for initialization
	void Start () {

			descript = GameObject.Find("Description").GetComponent<Text>();
			currentImage = GameObject.Find("MainImage").GetComponent<Image>();
			backbutton = GameObject.Find("Back Button").GetComponent<Button>();
			nextbutton = GameObject.Find("Next Button").GetComponent<Button>();
			currentPage = 0;
			backbutton.enabled = false;
			nextbutton.enabled = true;

			currentImage.sprite = image[0];
			descript.text = descript_str[0];
	}
}
