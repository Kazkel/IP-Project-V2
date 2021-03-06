﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;
    Animator anim;
    bool isRunning = false;
    public float jumpForce = 280f;
    public LayerMask theGround;
    public Transform groundCheck;
    bool onTheGround = false;
    public static int whichWeapon = 1;
	public float fireRate = 0.5f;
	public float timeLeft = 3.0f;
	
    
    


    public GameObject bulletToRight, bulletToLeft, gameOverText,  winText, level2Text, level2Button, restartButton, restartLevelButton, blood, blastToRight,
                      blastToRight1, blastToRight2, blastToLeft, blastToLeft1, blastToLeft2, mainCamera;    

    Vector2 bulletPos;
   
    float nextFire = 0.0f;

   

    // Use this for initialization
    void Start()
    {        

        gameOverText.SetActive(false);
        winText.SetActive(false);
        restartButton.SetActive(false);

        rigBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);

        if (velX != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        anim.SetBool("isRunning", isRunning);
        onTheGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);
        anim.SetBool("onTheGround", onTheGround);
        if (onTheGround && Input.GetButtonDown("Jump"))
        {
            SoundManagerScript.PlaySound("jump");
            velY = 0f;
            rigBody.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            mainCamera.GetComponent<CameraFollowScript>().shakeWeight = 0.08f;
            mainCamera.GetComponent<CameraFollowScript>().shakeTimer = 0.1f;
            SoundManagerScript.PlaySound("fire");
            nextFire = Time.time + fireRate;
            fire();
        }
        
		


		
		if (fireRate < 0.5f)
        {
			Invoke("fixShot", 3);
		}
            
        



    }

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        }
        else if (velX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    

    void fire()
    {
        bulletPos = transform.position;
        if (facingRight)
        {
            bulletPos += new Vector2(+1f, 0.64f);
            if (whichWeapon == 1)
            {
                
                Instantiate(bulletToRight, bulletPos, Quaternion.identity);
            }
            else
            {
                
                Instantiate(blastToRight, bulletPos, Quaternion.identity);
                Instantiate(blastToRight1, bulletPos, Quaternion.identity);
                Instantiate(blastToRight2, bulletPos, Quaternion.identity);
                
            }
        }
        else
        {
            bulletPos += new Vector2(-1f, 0.64f);
            if (whichWeapon == 1)
            {
                
                Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
            }
            else
            {
                
                Instantiate(blastToLeft, bulletPos, Quaternion.identity);
                Instantiate(blastToLeft1, bulletPos, Quaternion.identity);
                Instantiate(blastToLeft2, bulletPos, Quaternion.identity);
                
            }
        }
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag.Equals("Enemy"))
        //{
        //  SoundManagerScript.PlaySound("playerDeath");
        //gameOverText.SetActive(true);
        //restartButton.SetActive(true);
        //Instantiate(blood, transform.position, Quaternion.identity);
        //gameObject.SetActive(false);

        //}

        switch (col.gameObject.tag)
        {
            case "Enemy":                
                HealthBarScript.health -= 10f;
                mainCamera.GetComponent<CameraFollowScript>().shakeWeight = 0.5f;
                mainCamera.GetComponent<CameraFollowScript>().shakeTimer = 0.3f;
                break;

            case "BigEnemy":
                HealthBarScript.health -= 20f;
                mainCamera.GetComponent<CameraFollowScript>().shakeWeight = 0.5f;
                mainCamera.GetComponent<CameraFollowScript>().shakeTimer = 0.3f;
                break;



        }

        if (col.gameObject.tag.Equals("Win"))
        {
            
            winText.SetActive(true);
            restartLevelButton.SetActive(true);            
            gameObject.SetActive(false);

        }
        if (col.gameObject.tag.Equals("level2"))
        {

            level2Text.SetActive(true);
            level2Button.SetActive(true);
            gameObject.SetActive(false);

        }


    }


    public void changeWeapon()
    {
        if (whichWeapon == 1)
        {
            whichWeapon = 2;
			anim.SetInteger("whichWeapon", 2);

        }
        else
        {
            whichWeapon = 1; 
			anim.SetInteger("whichWeapon", 1);
        }

        


    }

    public void fixShot()
	{
		fireRate=0.5f;

	}
}

