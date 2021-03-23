using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysDestroyer : MonoBehaviour {

	private ParticleSystem ps;

	// Use this for initialization
	void Awake () {
		ps = GetComponent<ParticleSystem> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ps.IsAlive ())
			Destroy (gameObject);
	}
}
