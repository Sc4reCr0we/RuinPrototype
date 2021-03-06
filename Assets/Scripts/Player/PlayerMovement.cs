﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
		
	public float speed;
	public float turnSpeed;
	private Animator animator;
	private bool canMove = true;
	private bool isPushedback = false;
	
	void Start ()
	{
		//speed *= 100f;
		animator = GetComponent<Animator> ();
	}
	
	void Update () 
	{
		Vector3 direction = new Vector3(0,0,0);
		
		//Left
		
		if (Input.GetKey ("a"))
		{
			direction -= Vector3.right;
		}
		
		//Right 
		if(Input.GetKey("d"))
		{
			direction += Vector3.right;
		}
		
		//Up
		
		if (Input.GetKey ("w"))
		{
			direction += Vector3.up;     
		}
		
		//Down
		
		if(Input.GetKey ("s"))
		{
			direction -= Vector3.up;
		}
		

		if (canMove && !isPushedback)

		{
			rigidbody2D.velocity = direction.normalized*speed;
		}
		
		float targetAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		if (canMove && !isPushedback && (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w"))) 
		{
			
			if(animator.GetBool("moving") == false)
			{
				animator.SetBool("moving", true);
			}
			
			transform.rotation =
				Quaternion.Slerp (transform.rotation,
				                  Quaternion.Euler (0, 0, targetAngle),
				                  turnSpeed * Time.deltaTime);
		}
		else if (animator.GetBool ("moving") == true && !isPushedback) 
		{
			animator.SetBool ("moving", false);
			rigidbody2D.velocity = Vector2.zero;
		}

		
	}
	
	public void stopCasting()
	{
		if (animator.GetBool ("casting") == true) 
		{
			animator.SetBool ("casting", false);
		}
		canMove = false;
		
	}
	
	public void castingEnd()
	{
		canMove = true;
	}

	public void castingEnd2()
	{
		canMove = true;
	}

	public void setPushedback(float dist){
		isPushedback = true;
		calcPushTime (dist);
	}

	public void setPushStop(){
		isPushedback = false;
		}

	private void calcPushTime(float dist){
		float speedTemp;
		float timeTemp;
		speedTemp = rigidbody2D.velocity.magnitude;

		timeTemp = dist / speedTemp;
		if (isPushedback) {
			Invoke("setPushStop",1f);
				}
	}
}