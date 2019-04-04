using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Loads the scene
    public void restartScene()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Prototype 1");
    }
}
