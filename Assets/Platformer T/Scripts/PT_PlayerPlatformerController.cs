using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PT_PlayerPlatformerController : PT_PhysicsObject {

	[SerializeField] private float	maxSpeed = 7f;
	//[SerializeField] private float	jumpTakeOffSpeed = 7f;

	[SerializeField] private GameObject waveParticles;

	[SerializeField] private AudioSource shockWaveAudio;

	//private SpriteRenderer sr;
	private Animator anim;
	private Vector2 move = Vector2.zero;
	private bool isMoving = true;

	// Use this for initialization
	void Start () {
		//sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	public void StopMovement () {
		isMoving = false;
	}

	public void ContinueMovement () {
		isMoving = true;
	}

	public void ShakeCamera () {
		
		CameraShaker.Instance.ShakeOnce (1f, 1f, 0.1f, 1f);

		GameManager.instance.PsycoBoost = true;

	}

	private void PlayWave () {
		shockWaveAudio.Play ();
	}

	public void StartWave () {

		Instantiate (waveParticles, transform);
		Invoke ("PlayWave", 0.5f);
		
	}
	
	protected override void ComputeVelocity () {

		if(isMoving)
			move.x = Input.GetAxis ("Horizontal");
		else
			move.x = 0;

		/*if(Input.GetButtonDown("Jump") && grounded){
			
			velocity.y = jumpTakeOffSpeed;

		}else if(Input.GetButtonUp("Jump")){
			
			if(velocity.y > 0)
				velocity.y = velocity.y * 0.5f;
			
		}*/

		/*bool flipSprite = (sr.flipX ? (move.x > 0.01f) : (move.x < -0.01f));

		if (flipSprite) {
			sr.flipX = !sr.flipX;
		}*/

		if(Input.GetKeyDown (KeyCode.Z)){
			anim.SetTrigger ("ShockWave");
		}

		// Setting Idle, Walking & Flipping Animations States
		if (move.x > 0) {
			anim.SetBool ("Flip", false);
			anim.SetBool ("WalkingL", false);
			anim.SetBool ("WalkingR", true);
		} else if (move.x < 0) {
			anim.SetBool ("Flip", true);
			anim.SetBool ("WalkingR", false);
			anim.SetBool ("WalkingL", true);
		} else {
			anim.SetBool ("WalkingR", false);
			anim.SetBool ("WalkingL", false);
		}			

		targetVelocity = move * maxSpeed;

	}

}
