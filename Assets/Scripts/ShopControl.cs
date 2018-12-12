using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour {
    public int currency;
    public Text messageText;
    public Text beatcoins;

    // Use this for initialization
	void Start () {

        beatcoins.text = PlayerPrefs.GetInt("BeatCoins").ToString();

        if (PlayerPrefs.HasKey("BeatCoins") == true)
        {
            currency = PlayerPrefs.GetInt("BeatCoins");
            messageText.text = "";
        }
        else
        {
            currency = 0;
        }
	}

    public void BuyAmbrosia()
    {
        if(currency >= 30)
        {
            currency -= 30;
            if (PlayerPrefs.HasKey("Ambrosia") == true)
            {
                int amt = PlayerPrefs.GetInt("Ambrosia") + 1;
                PlayerPrefs.SetInt("Ambrosia", amt);
            }
            else
            {
               PlayerPrefs.SetInt("Ambrosia", 1);
            }
            messageText.text = "Bought Ambrosia!";
            PlayerPrefs.SetInt("BeatCoins",(PlayerPrefs.GetInt("BeatCoins") - 30));

        }
        else
        {
            messageText.text = "Not enough money for Ambrosia!";
        }
        beatcoins.text = PlayerPrefs.GetInt("BeatCoins").ToString();
    }

    public void BuyFleece()
    {
        if (currency >= 60)
        {
            currency -= 60;
            if (PlayerPrefs.HasKey("Golden Fleece") == true)
            {

                int amt = PlayerPrefs.GetInt("Golden Fleece") + 1;
                PlayerPrefs.SetInt("Golden Fleece", amt);

            }
            else
            {
                PlayerPrefs.SetInt("Golden Fleece", 1);
            }
            messageText.text = "Bought Golden Fleece!";
            PlayerPrefs.SetInt("BeatCoins",(PlayerPrefs.GetInt("BeatCoins") - 60));
        }
        else
        {
            messageText.text = "Not enough money for Golden Fleece!";
        }
        beatcoins.text = PlayerPrefs.GetInt("BeatCoins").ToString();
    }

    public void BuySandals()
    {
        if (currency >= 100)
        {
            currency -= 100;
            if (PlayerPrefs.HasKey("Hermes Sandals") == true)
            {
                currency -= 30;
                int amt = PlayerPrefs.GetInt("Hermes Sandals") + 1;
                PlayerPrefs.SetInt("Hermes Sandals", amt);
            }
            else
            {
                PlayerPrefs.SetInt("Hermes Sandals", 1);
            }
            messageText.text = "Bought Sandals of Hermes!";
            PlayerPrefs.SetInt("BeatCoins",(PlayerPrefs.GetInt("BeatCoins") - 100));
        }
        else
        {
            messageText.text = "Not enough money for Hermes' Sandals!";
        }
        beatcoins.text = PlayerPrefs.GetInt("BeatCoins").ToString();
    }

    public void LoadLevelSelect()
    {
        PlayerPrefs.SetInt("BeatCoins", currency);
        SceneManager.LoadScene("level select");
    }

}
