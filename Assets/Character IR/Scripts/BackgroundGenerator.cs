using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject[] backgrounds;
	public Transform generationPoint = null;

	// Use this for initialization
	void Start () {
		if(generationPoint == null)
			generationPoint = GameObject.Find("BackgroundDestructionPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (generationPoint.position.x < -30)
			generationPoint.position = new Vector3 (-25, 0, 0);
		
		if (generationPoint != null ) {
			foreach (GameObject bg in backgrounds) {
				if (bg.transform.position.x < generationPoint.position.x) {
					bg.transform.position = new Vector3 (bg.transform.position.x + 96, bg.transform.position.y, 2);
				}
			}
		}
	}
}
