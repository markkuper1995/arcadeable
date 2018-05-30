using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class SoundSettings : MonoBehaviour {

	public AudioSource sound;
	public GameObject buttonMenuSound;
	public bool multiplySounds = false;

	int[] menuSoundStartingPoint = new int[]{ 0, 284, 497, 701, 927, 1097, 1291 };

	bool soundPlaying = true;
	bool soundStarted = false;


	// Use this for initialization
	void Start () {
		soundPlaying = PlayerPrefsX.GetBool ("MusicOn", true);
		sound = GetComponent<AudioSource> ();

		if(!soundPlaying)
			buttonMenuSound.transform.Find("Text").GetComponent<Text>().text = "Sound: OFF";

		if(multiplySounds)
			sound.time = menuSoundStartingPoint[Random.Range (0, menuSoundStartingPoint.Length)];
	}

	// Update is called once per frame
	void Update () {
		if (soundPlaying == true && soundStarted == false) {
			sound.Play();
			soundPlaying = true;
			soundStarted = true;
		}
		if(soundPlaying == false && soundStarted == true){
			sound.Pause();
			soundStarted = false;
		}
		Debug.Log ( sound.time );
	}

	public void ToggleMenuSound() {
		if (soundPlaying) {
			//Change all the sound buttons in the app.
			Text text = buttonMenuSound.transform.Find("Text").GetComponent<Text>();
			text.text = "Sound: OFF";
			soundPlaying = false;
			PlayerPrefsX.SetBool ("MusicOn", false);
		} else {
			//Change all the sound buttons in the app.
			Text text = buttonMenuSound.transform.Find("Text").GetComponent<Text>();
			text.text = "Sound: ON";
			soundPlaying = true;
			PlayerPrefsX.SetBool ("MusicOn", true);
		}
	}

}
