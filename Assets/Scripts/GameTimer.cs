using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100f;
	
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	private GameObject coreGame;

	void Start () {
		slider= GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();	
		levelManager = FindObjectOfType<LevelManager>();
		FindYouWin ();
		FindCoreGame();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create 'You Win' object");
		}
	}
	
	void FindCoreGame ()
	{
		coreGame = GameObject.Find ("Core Game");
		if (!coreGame) {
			Debug.LogWarning ("Please create 'Core Game' object");
		}
	}
	
	void Update () {
		slider.value = (Time.timeSinceLevelLoad / levelSeconds);
		
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		
		if (timeIsUp && !isEndOfLevel){
			audioSource.Play ();
			winLabel.SetActive(true);
			coreGame.GetComponent<BoxCollider2D>().enabled = false; // Deactivate core game panel, so you cannot place new defenders
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
