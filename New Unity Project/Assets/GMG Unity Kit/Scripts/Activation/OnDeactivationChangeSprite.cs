﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeactivationChangeSprite : MonoBehaviour {

	// Use this for initialization

	public SpriteRenderer sprite;
	public Sprite newSprite;
	void Start () {
		if (sprite == null) sprite = GetComponent<SpriteRenderer>();
		GetComponent<Activatable>().onActivate += onActivate;
	}
	
	public void onActivate(bool activated)
	{
		if (!activated)
		{
			sprite.sprite = newSprite;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

}
