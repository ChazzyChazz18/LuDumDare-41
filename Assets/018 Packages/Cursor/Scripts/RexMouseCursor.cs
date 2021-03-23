using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RexMouseCursor : MonoBehaviour {

	[SerializeField] private Sprite standartCursor;
	[SerializeField] private Sprite holdingCursor;

	[SerializeField] private GameObject clickEffect;
	[SerializeField] private ParticleSystem trialEffect;

	private SpriteRenderer sr;
	private ParticleSystemRenderer psr;

	// Use this for initialization even before Start
	void Awake () {

		Cursor.visible = false;

		sr = GetComponent<SpriteRenderer> ();

		psr = clickEffect.GetComponent<ParticleSystemRenderer> (); // here we call the renderer of the Particle System
	}

	// Use this for initialization
	void Start () {

		sr.sprite = standartCursor;

		sr.sortingLayerName = "Cursor";
		psr.sortingLayerName = "Cursor";
	}

	//
	private void Move () {

		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.position = cursorPos;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.mousePosition.magnitude != 0)
			Move ();

		if (Input.GetMouseButtonDown (0)) {

			if (holdingCursor != null)
				sr.sprite = holdingCursor;
			else
				sr.sprite = standartCursor;

			Instantiate (clickEffect, transform.position, Quaternion.identity, transform.parent);

		} else if (Input.GetMouseButtonUp (0)) {

			sr.sprite = standartCursor;

		}

		if (Cursor.visible) // we make sure that the normal pointer of the mouse dont show's up in the game window
			Cursor.visible = false;		
	}
}