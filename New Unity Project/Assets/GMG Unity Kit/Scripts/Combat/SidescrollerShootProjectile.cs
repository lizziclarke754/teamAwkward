using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollerShootProjectile : MonoBehaviour {

	public GameObject projectilePrefab;
	public InputManager.InputButton shootButton = InputManager.InputButton.Action1;
	public float projectilesPerSecond = 5f;
	public float projectileSpeed = 1f;
	//Note make public in next release
	bool fireOnlyIfGrounded = false;
	public bool fireInDirectionOfMouseCursor = false;

	InputManager inputMgr;
	Animator animator;
	SpriteRenderer sprite;
	// Use this for initialization
	
	public AudioClip soundFile;
	public bool LoopSound = false;
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

	void Shoot()
	{
		if (fireOnlyIfGrounded && animator != null && !animator.GetBool("isGrounded")) return;

		GameObject projectile = null;
		if (projectilePrefab != null) projectile = Instantiate(projectilePrefab);

		SpriteRenderer projSprite = null;
		if (projectile != null)
		{
			projectile.transform.position = transform.position;
			projSprite = projectile.GetComponent<SpriteRenderer>();
			
			
			ConstantForce2D forceComponent = projectile.AddComponent<ConstantForce2D>();

			projSprite.flipX = sprite.flipX;
			if (fireInDirectionOfMouseCursor)
			{
				Transform targetTransform = projectile.transform;

				Vector3 vectorToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) - targetTransform.position;
				float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
				targetTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
							
				forceComponent.force = new Vector2(vectorToTarget.normalized.x * projectileSpeed, 
					vectorToTarget.normalized.y * projectileSpeed);
			}
			else
			{
				forceComponent.force = new Vector2((projSprite.flipX) ? -1*projectileSpeed : projectileSpeed, 0f);				
			}

			Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			if (!audioSrc.isPlaying) audioSrc.Play();
		}
	}
	
	// Update is called once per frame
	float fireRateCounter = 0f;
	void Update () 
	{
		if (fireRateCounter > (1f / projectilesPerSecond))
		{
			fireRateCounter = 0f;
		}
		else if (fireRateCounter != 0f)
		{
			fireRateCounter += Time.deltaTime;
		}

		if (inputMgr.GetKeyUp(shootButton) && animator != null)
		{
			animator.SetBool("isShooting", false);
			audioSrc.Stop();
		}

		if (inputMgr.GetKeyDown(shootButton) && animator != null) animator.SetBool("isShooting", true);

		if (inputMgr.GetKey(shootButton))
		{
			if (animator != null) animator.SetBool("isShooting", true);

			if (fireRateCounter == 0f)
			{
				Shoot();
				fireRateCounter += Time.deltaTime;
			}
		}

	}
}
