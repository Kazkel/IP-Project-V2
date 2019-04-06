using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	public float speed;
	public float aggroRange;
    Animator anim;
    bool isRunning = false;

	private Transform target;


	void Start () 
	{
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	
	}

	void Update()
	{
		if(Vector2.Distance(transform.position, target.position) < aggroRange)
		{
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
        if (Vector2.Distance(transform.position, target.position) > aggroRange)
        {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);
            
        }
    }
	
	
	
	
		
	
}
