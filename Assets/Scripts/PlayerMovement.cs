using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//transform.Translate (Vector2.right * speed);
	//transform.position += vector2.right * speed;
	//rigidbody2D.AddForce (Vector2.right);
	//rigidbody2D.velocity = Vector2.right;

	public float speed;
	public float turnSpeed;
	private Animator animator;
	private bool canMove = true;

	void Start ()
	{
		animator = GetComponent<Animator> ();
		speed *= 1000f;
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
		  	rigidbody2D.AddForce(direction.normalized*speed*Time.deltaTime);
		}
			
		float targetAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		if (canMove && (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w"))) 
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
}

