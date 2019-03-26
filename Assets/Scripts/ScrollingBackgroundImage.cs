using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundImage : MonoBehaviour
{
    public float scrollX = 0.01f;
    public float scrollY = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = transform.position.x * scrollX;
        float offsetY = transform.position.y * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
