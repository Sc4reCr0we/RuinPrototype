using UnityEngine;
using System.Collections;

public class PushbackScript : MonoBehaviour {

	public float maxStack;
	public float minStack;
	public float pushStack;

	public void pushPlayer(Vector3 hitLocation, float pushback, float stackAdd,Transform self){
		rigidbody2D.velocity = Vector2.zero;
		float pushbackCalced;
		pushbackCalced = pushback + (pushback * pushStack);
		Vector2 direction = self.position - transform.position;
		rigidbody2D.AddForce(-direction.normalized*pushbackCalced,ForceMode2D.Impulse);
		addStack (stackAdd);
		gameObject.GetComponent<PlayerMovement> ().setPushedback (pushbackCalced);
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
		pushStack += stackAdd/100;
	}

	// Use this for initialization
	void Awake () {
		pushStack = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkStack ();

	}
}
