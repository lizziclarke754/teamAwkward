using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerJump : MonoBehaviour {
	public float jumpPower = 200;
	public int maxJumps = 1;
	public InputManager.InputButton jumpButton = InputManager.InputButton.Up1;

	int jumpCounter = 0;
	
	// Use this for initialization
	bool grounded = true;
	Rigidbody2D rigidbody2D;
	Animator animator;
	InputManager inputMgr;

	public AudioClip soundFile;
	public bool LoopSound = false;
	AudioSource audioSrc;
	void Start ()
	{
		audioSrc = gameObject.AddComponent<AudioSource>();
		audioSrc.clip = soundFile;
		audioSrc.loop = LoopSound;

		animator = GetComponent<Animator>();

		rigidbody2D = GetComponent<Rigidbody2D>();
		if(rigidbody2D.velocity.y == 0) grounded = true;
    	else grounded = false;

    	if (animator) animator.SetBool("isGrounded", grounded);
		inputMgr = GameManager.Inst().GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!grounded && Mathf.Abs(rigidbody2D.velocity.y)<0.000001f)
		{
			audioSrc.Stop();
			grounded = true;
			ResetJumpCounter();
		}
		bool pressed = false;
		if (jumpButton == InputManager.InputButton.Up1) pressed = inputMgr.GetUpFirstPress();
		else pressed = inputMgr.GetKeyDown(jumpButton);

		if (pressed && (grounded == true || (jumpCounter < maxJumps && jumpCounter > 0)))
		{
			rigidbody2D.AddForce(transform.up*jumpPower);
			grounded = false;
			jumpCounter++;
			if (!audioSrc.isPlaying) audioSrc.Play();
		}

    	if (animator != null) animator.SetFloat("jumpSpeed", rigidbody2D.velocity.y);
    	//Debug.Log(animator.GetFloat("jumpSpeed"));
    	if (animator != null) animator.SetBool("isGrounded", grounded);
	}

	public void ResetJumpCounter()
	{
		jumpCounter = 0;
	}
}
