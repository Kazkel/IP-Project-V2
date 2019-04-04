using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour 
{

	public Text gameOver = null;
    public Text LivesText = null;
	public int health = 100;

	void OnCollisionEnter2D(Collision2D other)
	{
		health--;
		LivesText.text = ("Health :" + health);
		if (health == 0)
		{
			Destroy(GameObject.Find("Player"));
			gameOver.gameObject.SetActive(true);
			SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
            
		}
	}	
}

