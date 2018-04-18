using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    private ScoreManager scoreManager;
    private int coin = 1;
    
    // Use this for initialization
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            scoreManager.AddCoins(coin);
            gameObject.SetActive(false);
        }
    }
}
