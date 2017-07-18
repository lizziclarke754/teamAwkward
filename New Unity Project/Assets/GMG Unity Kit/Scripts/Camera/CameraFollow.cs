using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject CharacterToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CharacterToFollow != null)
        {
            //set the 
            this.gameObject.transform.position = new Vector3(CharacterToFollow.transform.position.x, CharacterToFollow.transform.position.y, this.transform.position.z);
        }
	}
}
