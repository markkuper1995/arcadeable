using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;
    private int deathCount;

    private PlatformDestroyer[] platformList;

    private ScoreManager scoreManager;

	public GameObject deathMenu;

	public Button pauseButton;

	public StartGame startGame;

	private GameObject[] backgrounds;

	private BackgroundGenerator backgroundGenerator;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

		backgroundGenerator = FindObjectOfType<BackgroundGenerator>();
		backgrounds = backgroundGenerator.backgrounds;

        scoreManager = FindObjectOfType<ScoreManager>();

        //Advertisement
        Advertisement.Initialize("2579476");
        deathCount = PlayerPrefs.GetInt("deathCount", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Death() {
		Time.timeScale = 0;
		deathMenu.SetActive(true);
		pauseButton.gameObject.SetActive (false);
        deathCount++;
        PlayerPrefs.SetInt("deathCount", deathCount);
        if (PlayerPrefs.GetInt("deathCount") == 5)
        {
            Advertisement.Show();
            deathCount = 0;
            PlayerPrefs.SetInt("deathCount", deathCount);
        }

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

		backgroundGenerator.generationPoint.position = new Vector3 (-25, 0, 0);
		backgroundGenerator.transform.position = new Vector3 (0, 0, 0);
		float positionX = -24;
		foreach (GameObject bg in backgrounds) {
			bg.transform.position = new Vector3 (positionX, bg.transform.position.y, bg.transform.position.z);
			positionX += 24;
		}
		StartCoroutine(startGame.ThreeTwoOne());
    }
}
