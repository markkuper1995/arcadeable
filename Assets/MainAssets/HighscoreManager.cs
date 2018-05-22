using System;
using UnityEngine.UI;
using UnityEngine;

namespace AssemblyCSharp
{
	public class HighscoreManager : MonoBehaviour
	{
		public Text highscoreTextDonald;
		public Text highscoreTextMark;
		public Text highscoreTextBolt;

		void Start() {
			if (PlayerPrefsX.GetFloatArray ("Highscore", 0, 0).Length != 0) {
				highscoreTextDonald.text = Mathf.Round ( PlayerPrefsX.GetFloatArray ("Highscore", 0, 0)[0] ).ToString();
				highscoreTextMark.text = Mathf.Round (PlayerPrefsX.GetFloatArray ("Highscore", 0, 0)[1]).ToString();
				highscoreTextBolt.text = Mathf.Round (PlayerPrefsX.GetFloatArray ("Highscore", 0, 0)[2]).ToString();
			} else {
				PlayerPrefsX.SetFloatArray ("Highscore", new float[3]{ 0,0,0 } );
			}
		}
	}
}  

