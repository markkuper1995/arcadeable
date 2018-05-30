using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private GameObject three;
	private GameObject two;
	private GameObject one;

	private bool afterThreeTwoOne = false;

	// Use this for initialization
	public void Start () {
		this.SetAfterThreeTwoOne (false);
		three = GameObject.Find ("3");
		two = GameObject.Find ("2");
		one = GameObject.Find ("1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GetAfterThreeTwoOne() {
		return this.afterThreeTwoOne;
	}

	public void SetAfterThreeTwoOne(bool afterTheeTwoOne) {
		this.afterThreeTwoOne = afterTheeTwoOne;
	}

	public IEnumerator ThreeTwoOne() {
		Time.timeScale = 1;
		this.SetAfterThreeTwoOne (false);

		three.SetActive (true);
		two.SetActive (false);	
		one.SetActive (false);	

		yield return new WaitForSeconds (1);

		three.SetActive (false);
		two.SetActive (true);

		yield return new WaitForSeconds (1);

		two.SetActive (false);
		one.SetActive (true);

		yield return new WaitForSeconds (1);

		one.SetActive (false);
		this.SetAfterThreeTwoOne (true);

		yield return null;
	}
}
