using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public GameObject three;
	public GameObject two;
	public GameObject one;

	public static bool afterThreeTwoOne = false;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		StartCoroutine(ThreeTwoOne());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ThreeTwoOne() {
		afterThreeTwoOne = false;

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
		afterThreeTwoOne = true;

		yield return null;
	}
}
