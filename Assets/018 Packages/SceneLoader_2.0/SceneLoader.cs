using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// WARNING!!! - Make sure to create a Sorting Layer on top of the others layers for this object on inspector

public class SceneLoader : MonoBehaviour {
	
	// Variables

	public static SceneLoader instance;

	[SerializeField] private float fadeTime = 1f;

	//
	[SerializeField] private GameObject overlay2 = null;

	//public GUITexture overlay;


	// Methods

	//
	void Awake () {
		
		instance = this;

		//overlay.pixelInset = new Rect (0,0,Screen.width,Screen.height);

		//
		//overlay2.transform.localScale = new Vector3 (Screen.width, Screen.height);

		/*overlay2.transform.position = new Vector3 (transform.position.x, transform.position.y, 
			Camera.main.transform.position.z + 1f);*/

		//Fade to clear
		StartCoroutine(FadeToClear());
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeToClear () {
		
		//overlay.gameObject.SetActive (true);

		//
		overlay2.SetActive (true);

		//overlay.color = Color.black;

		//
		overlay2.GetComponent<Image> ().color = Color.black;

		float rate = 1.0f / fadeTime;

		float progress = 0.0f;

		while(progress < 1.0f){
			
			//overlay.color = Color.Lerp (Color.black, Color.clear, progress);

			//
			overlay2.GetComponent<Image> ().color = Color.Lerp (Color.black, Color.clear, progress);

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//overlay.color = Color.clear;

		//
		overlay2.GetComponent<Image> ().color = Color.clear;

		//overlay.gameObject.SetActive (false);

		//
		overlay2.SetActive (false);
	}

	IEnumerator FadeToBlack (Action levelMethod) {
		
		//overlay.gameObject.SetActive (true);

		//
		overlay2.SetActive (true);

		//overlay.color = Color.clear;

		//
		overlay2.GetComponent<Image> ().color = Color.clear;

		float rate = 1.0f / fadeTime;

		float progress = 0.0f;

		while(progress < 1.0f){
			
			//overlay.color = Color.Lerp (Color.clear, Color.black, progress);

			//
			overlay2.GetComponent<Image> ().color = Color.Lerp (Color.clear, Color.black, progress);

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//overlay.color = Color.black;

		//
		overlay2.GetComponent<Image> ().color = Color.black;

		//overlay.gameObject.SetActive (false);
		levelMethod();
	}

	/// This method loads the scene by the name
	public void LoadSpecificScene (string name) {
		StartCoroutine (FadeToBlack (() => SceneManager.LoadScene (name)));
	}

	/// This method loads the scene by the index
	public void LoadSpecificScene (int index) {
		StartCoroutine (FadeToBlack (() => SceneManager.LoadScene (index)));
	}
}