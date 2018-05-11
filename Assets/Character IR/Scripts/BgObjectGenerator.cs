using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgObjectGenerator : MonoBehaviour {

	private Transform generationPoint = null;
	public GameObject[] backgrounds;
	private int lastIndex = 0;

	// Use this for initialization
	void Start () {
		generationPoint = GameObject.Find("BackgroundGenerationPoint").transform;
	}

	// Update is called once per frame
	void Update () {
		if (generationPoint != null && transform.position.x < generationPoint.position.x) {
			int index = Random.Range (0, 5);
			if (index == lastIndex)
				index++;
			GameObject newBackground = Instantiate(backgrounds[index]);

			transform.position = new Vector3(transform.position.x + Random.Range(10,25), backgrounds[index].transform.position.y, 1);
			newBackground.transform.position = transform.position;
			lastIndex = index;
		}
	}
}
