using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer spriteRenderer; //will store sprite renderer

    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>(); //get sprite renderer & store it
    }

    public void change(Sprite differentSprite)
    {
        spriteRenderer.sprite = differentSprite; //sets sprite renderers sprite
    }
}
