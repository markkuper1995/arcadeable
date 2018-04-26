using System;
using UnityEngine.UI;
using UnityEngine;

namespace AssemblyCSharp
{
	public class HighscoreManager : MonoBehaviour
	{
		public Text highscoreText;

		void Start() {
			if(PlayerPrefs.HasKey("Highscore"))
			{
				highscoreText.text = Mathf.Round(PlayerPrefs.GetFloat("Highscore")).ToString();
			}
		}
	}
}

