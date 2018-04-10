using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;

    private float platformWidth;

    private float distance;
    public float distanceMin;
    public float distanceMax;

    public GameObject[] platforms;
    private int platformSelector;

    //public ObjectPooler objectPool;
    
	// Use this for initialization
	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distance = Random.Range(distanceMin, distanceMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distance, transform.position.y, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);


            /* GameObject newPlatform = objectPool.getPooledObject();   
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true); */
        }
	}
}
