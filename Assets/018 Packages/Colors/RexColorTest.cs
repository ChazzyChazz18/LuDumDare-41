using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RexColorTest : MonoBehaviour {

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	//
	private void ChangeColor () {
		sr.color = RexColor.Navy;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeColor ();
	}
}
