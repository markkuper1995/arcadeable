using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager scoreManager;

	public GameObject deathMenu;

	public Button pauseButton;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Death() {
		Time.timeScale = 0;
		deathMenu.SetActive(true);
		pauseButton.gameObject.SetActive (false);
	}

    public void RestartGame() 
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.playerSpeed = player.startPlayerSpeed;
        player.increaseSpeedMilestone = player.startIncreaseSpeedMilestone;
        player.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive (true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
}
