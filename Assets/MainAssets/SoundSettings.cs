using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour {

	public AudioSource menuSound;
	public GameObject buttonMenuSound;

	bool menuSoundPlaying = true;
	bool menuSoundStarted = false;


	// Use this for initialization
	void Start () {
		menuSound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (menuSoundPlaying == true && menuSoundStarted == false) {
			menuSound.Play();
			menuSoundPlaying = true;
			menuSoundStarted = true;
		}
		if(menuSoundPlaying == false && menuSoundStarted == true){
			menuSound.Stop();
			menuSoundStarted = false;
		}
	}

	public void ToggleMenuSound() {
		if (menuSoundPlaying) {
			//Change all the sound buttons in the app.
			Text text = buttonMenuSound.transform.Find("Text").GetComponent<Text>();
			text.text = "Sound: OFF";
			menuSoundPlaying = false;
		} else {
			//Change all the sound buttons in the app.
			Text text = buttonMenuSound.transform.Find("Text").GetComponent<Text>();
			text.text = "Sound: ON";
			menuSoundPlaying = true;
		}
	}

}
