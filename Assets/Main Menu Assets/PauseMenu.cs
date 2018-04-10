using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenuPanel;
	public Text highScore;
	public Text currentScore;
	public int score = 0;

	// Use this for initialization
	void Start () {
		pauseMenuPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		currentScore.text = score.ToString();
	}

	public void HidePauseMenu() {
		pauseMenuPanel.SetActive (false);
	}

	public void ShowPauseMenu() {
		pauseMenuPanel.SetActive (true);
	}
}
