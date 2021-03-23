using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

	[SerializeField] private float fadeTime;
	[SerializeField] private Light ghostGlow;

	private bool isVisible = false;

	public bool IsVisible {
		get {
			return isVisible;
		}
	}

	// Use this for initialization
	void Start () {
		ghostGlow.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D () {

		if(!isVisible && GameManager.instance.PsycoBoost){
			StartCoroutine (Fadein ()
				/*FastMath.AlphaController (
				GetComponent<SpriteRenderer> ().color,
				fadeTime,
				0.35f
				)*/
			);
			isVisible = true;
		}
		
	}

	void OnTriggerStay2D () {

		if(!isVisible && GameManager.instance.PsycoBoost){
			StartCoroutine (Fadein ()
				/*FastMath.AlphaController (
					GetComponent<SpriteRenderer> ().color,
					fadeTime,
					0.35f
				)*/
			);
			isVisible = true;
		}
		
	}

	void OnTriggerExit2D () {

		/*if(isVisible)
			StartCoroutine (Fadeout ());*/

	}

	private IEnumerator Fadein () {
		float startAlphaSprite = GetComponent<SpriteRenderer> ().color.a;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			Color tempSpriteColor = GetComponent<SpriteRenderer> ().color;

			GetComponent<SpriteRenderer> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 0.35f, progress));
			
			progress += rate * Time.deltaTime;

			yield return null;
		}

		isVisible = true;
		ghostGlow.gameObject.SetActive (isVisible);
	}

	private IEnumerator Fadeout () {
		float startAlphaSprite = GetComponent<SpriteRenderer> ().color.a;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			Color tempSpriteColor = GetComponent<SpriteRenderer> ().color;

			GetComponent<SpriteRenderer> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 0, progress));

			progress += rate * Time.deltaTime;

			yield return null;
		}

		isVisible = false;
		ghostGlow.gameObject.SetActive (isVisible);
	}
	
	// Update is called once per frame
	void Update () {
		// Test
		/*if(Input.GetKeyDown (KeyCode.Q) && !isVisible){
			StartCoroutine (Fadein ());
		}
		if(Input.GetKeyDown (KeyCode.Q) && isVisible){
			StartCoroutine (Fadeout ());
		}*/

		if(!GetComponent<SpriteRenderer> ().isVisible && isVisible){ // here we make sure the ghost disappear when isn't seen
			StartCoroutine (Fadeout ()
				/*FastMath.AlphaController (
				GetComponent<SpriteRenderer> ().color,
				fadeTime,
				0
				)*/
			);
			isVisible = false;
		}
	}
}
