using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

	bool activated = false;
	public delegate void ActivationHandler(bool activated);
	public event ActivationHandler onActivate;

	public void Activate()
	{
		activated = !activated;
		if (onActivate != null) onActivate(activated);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
