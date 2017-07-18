using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager gameMgr;
	public static GameManager Inst()
	{
		if (gameMgr != null) return gameMgr;

		GameManager[] gameMgrs = Object.FindObjectsOfType(typeof(GameManager)) as GameManager[];
		foreach (GameManager gameManager in gameMgrs)
		{
			gameMgr = gameManager;
		}

		if (gameMgr == null)
		{
			GameObject gObject = Instantiate(Resources.Load("GameManager")) as GameObject;
			gameMgr = gObject.GetComponent<GameManager>();
		}

		return gameMgr;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
