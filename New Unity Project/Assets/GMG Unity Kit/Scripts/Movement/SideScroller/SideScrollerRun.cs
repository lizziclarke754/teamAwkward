using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerRun : MonoBehaviour {

	InputManager inputMgr;
	Animator animator;
	SpriteRenderer sprite;
	public float runSpeed = 0.1f;
	public bool cannotRunLeft = false;
	public bool cannotRunRight = false;

	public AudioClip soundFile;
	public bool LoopSound = true;
	AudioSource audioSrc;
	void Start ()
	{
		audioSrc = gameObject.AddComponent<AudioSource>();
		audioSrc.clip = soundFile;
		audioSrc.loop = LoopSound;
		
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		inputMgr = GameManager.Inst().GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (inputMgr.GetRight() && !cannotRunRight)
		{
			if (!audioSrc.isPlaying) audioSrc.Play();
			if (animator != null) animator.SetFloat("runSpeed", runSpeed);
			if (animator != null) animator.SetBool("FacingRight", true);
			sprite.flipX = false;
			transform.position = new Vector3(transform.position.x + runSpeed, transform.position.y, transform.position.z);
		}
		else if (inputMgr.GetLeft() && !cannotRunLeft)
		{
			if (!audioSrc.isPlaying) audioSrc.Play();
			if (animator != null) animator.SetFloat("runSpeed", runSpeed);
			if (animator != null) animator.SetBool("FacingRight", false);
			sprite.flipX = true;
			transform.position = new Vector3(transform.position.x - runSpeed, transform.position.y, transform.position.z);
		}
		else
		{
			audioSrc.Stop();
			if (animator != null) animator.SetFloat("runSpeed",0f);
		}
	
	}
}
