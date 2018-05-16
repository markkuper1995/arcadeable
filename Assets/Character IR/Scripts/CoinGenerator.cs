using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;
    
	public void SpawnCoins(Vector3 startPosition, int random)
    {

        if (random == 0)
        {
            GameObject coinOne = coinPool.getPooledObject();
            coinOne.transform.position = startPosition;
            coinOne.SetActive(true);
        }

        if (random == 1)
        {
            GameObject coinOne = coinPool.getPooledObject();
            coinOne.transform.position = new Vector3(startPosition.x + (distanceBetweenCoins / 2), startPosition.y, startPosition.z);
            coinOne.SetActive(true);

            GameObject coinTwo = coinPool.getPooledObject();
            coinTwo.transform.position = new Vector3(startPosition.x - (distanceBetweenCoins / 2) , startPosition.y, startPosition.z);
            coinTwo.SetActive(true);
        }

        if (random == 2)
        {
            GameObject coinOne = coinPool.getPooledObject();
            coinOne.transform.position = startPosition;
            coinOne.SetActive(true);

            GameObject coinTwo = coinPool.getPooledObject();
            coinTwo.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
            coinTwo.SetActive(true);

            GameObject coinThree = coinPool.getPooledObject();
            coinThree.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
            coinThree.SetActive(true);
        }


       
    }
}
