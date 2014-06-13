using UnityEngine;
using System.Collections;

public class PushbackScript : MonoBehaviour {

	public float maxStack;
	public float minStack;
	public float pushStack;
	public float pushbackSpeed = 100f;
	
	private float pushbackDistance;
	private Vector3 pushbackDirection;
	private bool isPushedback = false;	

	public void pushPlayer(Vector3 hitLocation, float pushback, float stackAdd,Transform self)
	{
		pushbackDirection = self.position - transform.position;
		pushbackDistance += pushback;
		isPushedback = true;
		addStack (stackAdd);
		pushbackDirection.Normalize ();

		
		
	}



	private void checkStack(){

		if (pushStack > maxStack) {
			pushStack = maxStack;
		}

		if (pushStack < minStack) {
			pushStack = minStack;
		}


	}

	private void addStack(float stackAdd){
		pushStack += stackAdd;
	}

	// Use this for initialization
	void Awake () {
		pushStack = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkStack ();
		//pushbackDistance = Mathf.Lerp (pushbackDistance, 0f, pushbackSpeed * Time.deltaTime);
		if(isPushedback)
		{
			rigidbody2D.velocity = pushbackDirection * (pushbackDistance + pushbackDistance * pushStack);
	
		}
	}
}
