using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
		
	public float speed;
	public float turnSpeed;
	private Animator animator;
	private bool canMove = true;
	private bool isPushedback = false;
	
	void Start ()
	{
		speed *= 100f;
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
		
		if (direction != Vector3.zero && canMove)
		{
			rigidbody2D.velocity = (direction.normalized*speed)*Time.deltaTime;
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
		else if (animator.GetBool ("moving") == true) 
		{
			animator.SetBool ("moving", false);
			rigidbody2D.velocity = Vector3.zero;
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
		Debug.Log ("canmove, true");
		canMove = true;
	}

	public void castingEnd2()
	{
		Debug.Log ("canmove, true");
		canMove = true;
	}
}