﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinScript : MonoBehaviour
{

    
    public PlayerController player;


    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "Player")
        {

            
            Destroy(gameObject);

        }

    }




}