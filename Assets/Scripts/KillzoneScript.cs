using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillzoneScript: MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                ScoreScript.scoreValue = 0;
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
}

