using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public GameObject three;
	public GameObject two;
	public GameObject one;


	// Use this for initialization
	void Start () {
		three = GameObject.Find ("3");
		two = GameObject.Find ("2");
		one = GameObject.Find ("1");

		StartCoroutine(ThreeTwoOne());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ThreeTwoOne() {
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
		Time.timeScale = 1;

		yield return null;
	}
}
