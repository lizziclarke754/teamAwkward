using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelfIfLeaveCamera : MonoBehaviour {

	void KillSelf()
	{
       gameObject.SetActive(false);
       Destroy(gameObject);	
	}

	void OnBecameInvisible()
	{
		KillSelf();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
