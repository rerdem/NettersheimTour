using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public int progress;

	void Awake () {
		if (instance == null) instance = this;
		else if (instance != null) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		progress = 0;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
