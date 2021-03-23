using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	[SerializeField] private float lifeTime = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy", lifeTime);
	}

	private void Destroy () {

		Destroy (gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
