using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActivationChangeScene : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	void Start () {
		GetComponent<Activatable>().onActivate += onActivate;
	}
	
	public void onActivate(bool activated)
	{
		if (activated)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
