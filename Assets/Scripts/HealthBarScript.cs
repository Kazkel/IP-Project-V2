using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    public float maxHealth = 100f;
    public static float health;
    public Text gameOver = null;
    public Button restartButton = null;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (health == 0)
        {
            Destroy(GameObject.Find("Player"));
            gameOver.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
}
