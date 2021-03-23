using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFader2 : MonoBehaviour {

	[SerializeField] private float fadeTime = 1f;
    [SerializeField] private int fadeRadious = 164;

    // Use this for initialization
    void Start () {

	}

	public IEnumerator Fadein () {
		//float startAlphaSprite = GetComponent<Image> ().color.a;
		float startScaleX = transform.localScale.x;
		float startScaleY = transform.localScale.y;
		//Vector3 startScale = transform.localScale;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			//Color tempSpriteColor = GetComponent<Image> ().color;
			//Vector3 tempScale = transform.localScale;

			//GetComponent<Image> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 1, progress));
			transform.localScale = new Vector3(Mathf.Lerp (startScaleX, fadeRadious, progress), Mathf.Lerp (startScaleY, fadeRadious, progress));

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//isVisible = true;
	}

	public IEnumerator Fadeout () {
		//float startAlphaSprite = GetComponent<Image> ().color.a;
		float startScaleX = transform.localScale.x;
		float startScaleY = transform.localScale.y;
		//Vector3 startScale = transform.localScale;

		float rate = 1.0f / fadeTime;
		float progress = 0.0f;

		while(progress < 1.1){
			//Color tempSpriteColor = GetComponent<Image> ().color;
			//Vector3 tempScale = transform.localScale;

			//GetComponent<Image> ().color = new Color (tempSpriteColor.r, tempSpriteColor.g, tempSpriteColor.b, Mathf.Lerp (startAlphaSprite, 1, progress));
			transform.localScale = new Vector3(Mathf.Lerp (startScaleX, 0, progress), Mathf.Lerp (startScaleY, 0, progress));

			progress += rate * Time.deltaTime;

			yield return null;
		}

		//isVisible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
