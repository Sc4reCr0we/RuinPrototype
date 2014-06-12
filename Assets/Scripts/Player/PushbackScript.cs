using UnityEngine;
using System.Collections;

public class PushbackScript : MonoBehaviour {

	public float maxStack;
	public float minStack;
	public float pushStack;

	public void pushPlayer(Vector3 hitLocation, float pushback, float stackAdd,Transform self){
		Vector2 direction = self.position - transform.position;
		Debug.Log("pushPlayer2");
		Debug.Log (direction.normalized * (pushback + pushback * pushStack));
		rigidbody2D.AddForce(direction.normalized*(pushback+pushback*pushStack));
		addStack (stackAdd);
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

	}
}
