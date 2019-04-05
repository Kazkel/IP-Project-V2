using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour 
{
	
	public float speed = 0.0001f;
	public float size =0.2f;
	public float timeLeft = 3.0f;
    public PlayerController player =null;
	public float shotDelay = 0.2f;
	
	float directionX = 0.0f;
    float directionY = 0.5f;
	private int angle = 90;
    

	public void OnCollisionEnter2D(Collision2D other)
	{
		
        if (other.gameObject.tag == "Player")
        {
			
            player.fireRate = shotDelay;
            Destroy(gameObject);

        }
		
        
    }

	public void SetDirection(int angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        directionX = Mathf.Cos(angleInRadians);
        directionY = Mathf.Sin(angleInRadians);
		
    }
		
	void FixedUpdate()
    {
        Vector3 scale = new Vector3();
        scale.x = size;
        scale.y = size;
        transform.localScale = scale;

        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.localPosition = position;
	}
	
	
}
