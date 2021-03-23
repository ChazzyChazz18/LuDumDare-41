using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour {

	public static SnakeManager instance;

	public enum States {BEFORESTART, GAME, GAMEOVER}

	[SerializeField] private GameObject beforeStartPanel;
	[SerializeField] private GameObject gameOverPanel;

	[SerializeField] private GameObject snakeHead;
	[SerializeField] private GameObject snakeTail;

	private States state;

	public States State {
		get {
			return state;
		}
		set {
			state = value;
		}
	}

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		state = States.BEFORESTART;
		gameOverPanel.SetActive (false);
	}

	public void ChangeGameState () {
		if (state == States.BEFORESTART)
			beforeStartPanel.SetActive (true);
		else if (state == States.GAME) {
			GameManager.instance.SnakeGameStarted = true;
			beforeStartPanel.SetActive (false);
		}
		else if (state == States.GAMEOVER)
			gameOverPanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (state == States.BEFORESTART) {
			if (Input.GetKeyDown (KeyCode.C)) {
				state = States.GAME;
				snakeHead.transform.position = new Vector3 (0.75f, 0.25f, 0);
				snakeTail.transform.position = new Vector3 (0.75f, -0.25f, 0);
				ChangeGameState ();
			} else if (Input.GetKeyDown (KeyCode.Z)) {
				GameManager.instance.LoadMainGame ();
			}
		}

		if (state == States.GAMEOVER) {
			if (Input.GetKeyDown (KeyCode.C)) {
				GameManager.instance.LoadSnakeGame ();
			} else if (Input.GetKeyDown (KeyCode.Z)) {
				GameManager.instance.LoadMainGame ();
			}			
		}
	}
}
