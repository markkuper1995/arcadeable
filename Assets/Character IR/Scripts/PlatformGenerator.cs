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

    //public GameObject[] platforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] objectPools;

    private float heightMin;
    public Transform heightMaxPoint;
    private float heightMax;
    public float heightMaxChange;
    private float heightChange;

    private CoinGenerator coinGenerator;
    public float randomCoinTreshold;
    
	// Use this for initialization
	void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[objectPools.Length];

        for (int i = 0; i < objectPools.Length; i++)
        {
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        heightMin = transform.position.y + 2;
        heightMax = heightMaxPoint.position.y; 

        coinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distance = Random.Range(distanceMin, distanceMax);
            platformSelector = Random.Range(0, objectPools.Length);

            heightChange = transform.position.y + Random.Range(heightMaxChange, -heightMaxChange);
            if (heightChange > heightMax)
            {
                heightChange = heightMax;
            }
            else if (heightChange < heightMin)
            {
                heightChange = heightMin;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distance, heightChange, transform.position.z);


            //Instantiate(/* platform */ platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = objectPools[platformSelector].getPooledObject();   
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinTreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
        }
	}
}
