using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsMain : MonoBehaviour {
	public GameObject panel;

	void Start() {
		panel.SetActive(false);
		panel.layer = 30;
	}

	public void ShowPanel() {
		panel.SetActive (true);
	}

	public void HidePanel() {
		panel.SetActive (false);
	}
}
