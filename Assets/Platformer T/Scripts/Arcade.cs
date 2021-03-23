//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Arcade : MonoBehaviour {

	[SerializeField] private Light arcadeLight;
    [SerializeField] private Collider2D playerCol;

    private Animator anim;

	private Color blueScreen = new Color (123, 214, 232);
	private Color yellowScreen = new Color (227, 221, 109);
	private Color redScreen = new Color (222, 118, 111);

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		arcadeLight.gameObject.SetActive (anim.GetBool ("isOn"));
	}

	public void SetBlueScreen () {
		arcadeLight.color = blueScreen;
	}

	public void SetYellowScreen () {
		arcadeLight.color = yellowScreen;
	}

	public void SetRedScreen () {
		arcadeLight.color = redScreen;
	}

	void OnTriggerEnter2D (Collider2D other) {
		GameManager.instance.IsNearArcade = true;
	}

	//
	void OnTriggerExit2D (Collider2D other) {
		GameManager.instance.IsNearArcade = false;
	}

	private void LoadArcadeGame () {

		GameManager.instance.LoadSnakeGame ();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C) && playerCol.CompareTag("Player") && GameManager.instance.IsNearArcade)
        {
            if (!anim.GetBool("isOn"))
            {
                GameManager.instance.PlayerPos = playerCol.transform.position;
                playerCol.GetComponent<PT_PlayerPlatformerController>().StopMovement();
                arcadeLight.gameObject.SetActive(true);
                anim.SetBool("isOn", true);
                Invoke("LoadArcadeGame", 2.25f);
            }
            else
            {
                arcadeLight.gameObject.SetActive(false);
                anim.SetBool("isOn", false);
            }
        }

    }
}
