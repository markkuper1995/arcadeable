using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Button[] buttons;
	public Text AmountCoins;

	// Use this for initialization
	void Start () {
		this.SetCoins();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetCoins() {
		AmountCoins.text = PlayerPrefs.GetInt( "Coins", 0 ).ToString();
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
				//button.GetComponentInChildren<Text> ().text = "Use";
				PlayerPrefs.SetInt ( "Coins", amount-n );
				this.SetCoins();
			}
		}
		int character;
		foreach (Button btn in buttons) {
			if (button.GetComponentInChildren<Text> ().text == "Use" && btn.GetComponentInChildren<Text> ().text == "In use") {
				btn.GetComponentInChildren<Text> ().text = "Use";
				button.GetComponentInChildren<Text> ().text = "In use";
				int.TryParse ( button.name.Substring ( button.name.Length - 1, 1 ), out character );
				PlayerPrefs.SetInt( "Character", character );
			}
		}
	}
}
