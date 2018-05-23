using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroyer : MonoBehaviour {
	
	public GameObject backgroundDestructionPoint;

	// Use this for initialization
	void Start () {
		backgroundDestructionPoint = GameObject.Find("BackgroundDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < backgroundDestructionPoint.transform.position.x)
			gameObject.SetActive(false);
	}
}
