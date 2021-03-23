using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rex_CameraShaker : MonoBehaviour {

	[SerializeField] private float power = 0.7f;
	[SerializeField] private float duration = 1.0f;
	[SerializeField] private Transform cameraTrans;
	[SerializeField] private float slowDownAmount = 1.0f;
	[SerializeField] private bool shouldShake = false;

	private Vector3 startPosition;
	float initialDuration;

	// Use this for initialization
	void Start () {
		cameraTrans = Camera.main.transform;
		startPosition = cameraTrans.localPosition;
		initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldShake){
			if (duration > 0) {
				cameraTrans.localPosition = startPosition + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			} else {
				shouldShake = false;
				duration = initialDuration;
				cameraTrans.localPosition = startPosition;
			}
		}
	}
}
