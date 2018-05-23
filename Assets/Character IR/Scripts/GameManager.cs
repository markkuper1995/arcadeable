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

	public GameObject[] backgrounds;

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
		backgrounds [0].transform.position = new Vector3 ( -24, backgrounds [0].transform.position.y, backgrounds [0].transform.position.z);
		backgrounds [1].transform.position = new Vector3 ( 0, backgrounds [1].transform.position.y, backgrounds [1].transform.position.z);
		backgrounds [2].transform.position = new Vector3 ( 24, backgrounds [2].transform.position.y, backgrounds [2].transform.position.z);
		backgrounds [3].transform.position = new Vector3 ( 48, backgrounds [3].transform.position.y, backgrounds [3].transform.position.z);
		Debug.Log (backgrounds [0].transform.position.x);
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
