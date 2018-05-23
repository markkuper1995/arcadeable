using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgObjectGenerator : MonoBehaviour {

	private Transform generationPoint = null;
	public GameObject[] backgrounds;
	private int lastIndex = -1;

	// Use this for initialization
	void Start () {
		generationPoint = GameObject.Find("BackgroundGenerationPoint").transform;
	}

	// Update is called once per frame
	void Update () {
		if (generationPoint != null && transform.position.x < generationPoint.position.x) {
			int index = Random.Range (0, backgrounds.Length);
			while (index == lastIndex) {
				index = Random.Range (0, backgrounds.Length);
			}
			if (index != lastIndex) {
				GameObject newBackground = Instantiate(backgrounds[index]);

				transform.position = new Vector3(transform.position.x + Random.Range(20,50), backgrounds[index].transform.position.y, 1);
				newBackground.transform.position = transform.position;
				lastIndex = index;
			}
		}
	}
}
