using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsMain : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
	}
	
	public void ShowPanel() {
		panel.SetActive (true);
	}

	public void HidePanel(){
		panel.SetActive (false);
	}
}
