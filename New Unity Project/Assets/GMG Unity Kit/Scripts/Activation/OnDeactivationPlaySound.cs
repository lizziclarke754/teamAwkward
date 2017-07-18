using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeactivationPlaySound : MonoBehaviour {

	// Use this for initialization

	public AudioClip sound;
	AudioSource audioSrc;
	void Start () {
		audioSrc = gameObject.AddComponent<AudioSource>();
		GetComponent<Activatable>().onActivate += onActivate;
	}
	
	public void onActivate(bool activated)
	{
		if (!activated)
		{
			audioSrc.clip = sound;
			audioSrc.Play();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

}
