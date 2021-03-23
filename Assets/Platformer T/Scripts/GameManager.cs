using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private int snakeScore = 0;

	private int snakeMaxScore = 0;

	private bool psycoBoost = false;

	private Vector3 playerPos = new Vector3 (88.433f, 1.385f, 0);

	private bool snakeGameStarted = false;

	private bool isNearArcade = false;

	public bool IsNearArcade {
		get {
			return isNearArcade;
		}
		set {
			isNearArcade = value;
		}
	}

	public bool SnakeGameStarted {
		get {
			return snakeGameStarted;
		}
		set {
			snakeGameStarted = value;
		}
	}

	public Vector3 PlayerPos {
		get {
			return playerPos;
		}
		set {
			playerPos = value;
		}
	}

	public bool PsycoBoost {
		get {
			return psycoBoost;
		}
		set {
			psycoBoost = value;
		}
	}

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}else if (instance != this) {
			Destroy (gameObject);
		}

		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Main")) {
			//Debug.Log ("hi main loaded");
			GameObject.FindObjectOfType<PT_PlayerPlatformerController> ().gameObject.transform.position = playerPos;
		}
	}

	public void LoadSnakeGame () {

		//SceneManager.LoadScene ("Snake_Main");
		SceneLoader.instance.LoadSpecificScene ("Snake_Main");
		
	}

	public void LoadMainGame () {

		SceneManager.LoadScene ("Main");

	}
		
	private void StopPsycoBoost () {
		psycoBoost = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(snakeScore > snakeMaxScore){
			snakeMaxScore = snakeScore;
		}

		if (psycoBoost)
			Invoke ("StopPsycoBoost", 4f);
	}
}
