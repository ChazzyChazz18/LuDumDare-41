using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarpFader : MonoBehaviour {

	[SerializeField] private float fadeTime = 1f;

	// Use this for initialization
	void Start () {
		
	}

	public IEnumerator Fadein () {
		float startAlphaSprite = GetComponent<Image> ().color.a;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			Color tempSpriteColor = GetComponent<Image> ().color;

			GetComponent<Image> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 1, progress));

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//isVisible = true;
	}

	public IEnumerator Fadeout () {
		float startAlphaSprite = GetComponent<Image> ().color.a;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			Color tempSpriteColor = GetComponent<Image> ().color;

			GetComponent<Image> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 0, progress));

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//isVisible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
