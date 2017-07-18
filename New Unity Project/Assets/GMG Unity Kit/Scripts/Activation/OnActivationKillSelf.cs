using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActivationKillSelf : MonoBehaviour {

	// Use this for initialization

	void Start () {
		GetComponent<Activatable>().onActivate += onActivate;
	}
	
	public void onActivate(bool activated)
	{
		if (activated)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
