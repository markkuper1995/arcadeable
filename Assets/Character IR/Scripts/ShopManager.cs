using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using System;

public class ShopManager : MonoBehaviour {

	public Button[] buttons;
	public Text AmountCoins;

	// Use this for initialization
	void Start () {
		this.SetCoins();
		this.SetStore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetCoins() {
		AmountCoins.text = PlayerPrefs.GetInt( "Coins", 0 ).ToString();
	}

	private void SetStore() {
		String[] characters = PlayerPrefsX.GetStringArray ("Characters");
		if (characters.Length == 0) {
			PlayerPrefsX.SetStringArray ("Characters", new string[] {"In use", "Use", "10000", "20000" } );
			PlayerPrefs.SetInt("CurrentCharacter", 0);
		}
		int index = 0;
		foreach (String c in characters) {
			int n;
			if (int.TryParse (c, out n)) {
				this.buttons [index].GetComponentInChildren<Text> ().text = "        " + n;
			} else {
				foreach (Transform child in this.buttons[index].transform) {
					if (child.name == "Text") {
						this.buttons [index].GetComponentInChildren<Text> ().text = c;
					} else {
						Destroy (child.gameObject);
					}
				}
			}
			index++;
		}
	}

	public void ToggleButton(Button button) {
		int n;
		if (int.TryParse (button.GetComponentInChildren<Text> ().text, out n)) {
			int amount = PlayerPrefs.GetInt( "Coins", 0 );
			if (amount > n) {
				foreach (Transform child in button.transform) {
					if (child.name == "Text") {
						child.GetComponent<Text> ().text = "Use";
					} else {
						Destroy (child.gameObject);
					}
				}

				//Update Characters
				int a = -1;
				int.TryParse (button.name.Substring (button.name.Length - 1, 1), out a);
				String[] characters = PlayerPrefsX.GetStringArray ("Characters");
				if (a != -1)
					characters [a] = "Use";
				PlayerPrefsX.SetStringArray ("Characters", characters);

				//Update coins
				PlayerPrefs.SetInt ("Coins", amount - n);
				this.SetCoins ();
			} else {
				//Warning
			}
		}
		int character = -1;
		foreach (Button btn in buttons) {
			if (button.GetComponentInChildren<Text> ().text == "Use" && btn.GetComponentInChildren<Text> ().text == "In use") {
				btn.GetComponentInChildren<Text> ().text = "Use";
				button.GetComponentInChildren<Text> ().text = "In use";
				int.TryParse ( button.name.Substring ( button.name.Length - 1, 1 ), out character );
				PlayerPrefs.SetInt( "CurrentCharacter", character );

				//Update Characters
				int a = -1;
				int b = -1;
				String[] characters = PlayerPrefsX.GetStringArray ("Characters");

				int.TryParse (button.name.Substring (button.name.Length - 1, 1), out a);
				if (a != -1)
					characters [a] = "In use";
				int.TryParse (btn.name.Substring (btn.name.Length - 1, 1), out b);
				if (b != -1)
					characters [b] = "Use";
				PlayerPrefsX.SetStringArray ("Characters", characters);
			}
		}

	}

	public void BuyCoins(int amount) {
		//Koppeling maken met GooglePlay voor betaling
		amount = 0;

		int currentAmount = PlayerPrefs.GetInt( "Coins", 0 );
		PlayerPrefs.SetInt ("Coins", currentAmount + amount);
		this.SetCoins ();
	}
}
