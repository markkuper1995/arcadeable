using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject background;
	private Transform generationPoint = null;

	// Use this for initialization
	void Start () {
		generationPoint = GameObject.Find("BackgroundGenerationPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (generationPoint != null && transform.position.x < generationPoint.position.x) {
			GameObject newBackground = Instantiate(background);

			transform.position = new Vector3(transform.position.x + 46, background.transform.position.y, 2);
			newBackground.transform.position = transform.position;
		}
	}
}
