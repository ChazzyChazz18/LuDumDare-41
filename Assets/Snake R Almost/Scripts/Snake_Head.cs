//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake_Head : MonoBehaviour {

	enum Direction{ UP, RIGHT, DOWN, LEFT}

	[SerializeField] private float frameRate = 0.2f;
	[SerializeField] private float step = 0.48f;

	[SerializeField] private List<Transform> tail = new List<Transform> ();

	[SerializeField] private GameObject tailPrefab;

	[SerializeField] private Vector2 horizontalRange;
	[SerializeField] private Vector2 verticalRange;

	[SerializeField] private Text scoreText;

	[SerializeField] private AudioSource eatSound;
	[SerializeField] private AudioSource crashSound;
	[SerializeField] private AudioSource powerUpSound;

	Direction direction;

	private int score;

	private Vector3 lastPos;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Move", frameRate, frameRate);
		score = 0;
		scoreText.text = "Score: " + score.ToString ();
	}

	//
	private void Move () {

		lastPos = transform.position;
		
		Vector3 nextPos = Vector3.zero;

		if (direction == Direction.UP) {
			nextPos = Vector3.up;
        }

		if (direction == Direction.RIGHT) {
			nextPos = Vector3.right;
        }

		if (direction == Direction.DOWN) {
			nextPos = Vector3.down;
        }

		if (direction == Direction.LEFT) {
			nextPos = Vector3.left;
            
		}

		nextPos *= step;

		transform.position += nextPos;

        MoveTail ();
	}

	//
	private void MoveTail () {

		for (int i = 0; i < tail.Count; i++) {

			Vector3 temp = tail [i].position;
			tail [i].position = lastPos;
			lastPos = temp;

		}

	}

	//
	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag ("Boundary")){

			crashSound.Play ();

			SnakeManager.instance.State = SnakeManager.States.GAMEOVER;

			SnakeManager.instance.ChangeGameState ();
			
		}else if(other.CompareTag ("Food")){

			eatSound.Play ();

			score += 10;

			scoreText.text = "Score: " + score.ToString ();

			tail.Add (Instantiate (tailPrefab, tail [tail.Count - 1].position, Quaternion.identity).transform);

			other.transform.position = new Vector2 (Random.Range ((int)horizontalRange.x, (int)horizontalRange.y) * step - (step / 2), 
				Random.Range ((int)verticalRange.x, (int)verticalRange.y) * step - (step / 2)); 

		}

	}
	
	// Update is called once per frame
	void Update () {

		if(SnakeManager.instance.State == SnakeManager.States.GAME){

            if (Input.GetKeyDown (KeyCode.UpArrow) && direction != Direction.DOWN) {
				direction = Direction.UP;
                //transform.eulerAngles = Vector3.forward * 270; //For the head rotation
            }

			if (Input.GetKeyDown (KeyCode.RightArrow) && direction != Direction.LEFT) {
				direction = Direction.RIGHT;
                //transform.eulerAngles = Vector3.forward * 180;
            }

			if (Input.GetKeyDown (KeyCode.DownArrow) && direction != Direction.UP) {
				direction = Direction.DOWN;
                //transform.eulerAngles = Vector3.forward * 90;
            }

			if (Input.GetKeyDown (KeyCode.LeftArrow) && direction != Direction.RIGHT) {
				direction = Direction.LEFT;
                //transform.eulerAngles = Vector3.forward * 0;
            }

        }

	}
}
