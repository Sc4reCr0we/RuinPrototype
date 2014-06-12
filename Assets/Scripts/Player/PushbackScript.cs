using UnityEngine;
using System.Collections;

public class PushbackScript : MonoBehaviour {

	public float maxStack;
	public float minStack;
	public float pushStack;

	public void pushPlayer(Vector2 hitLocation, float pushback, float stackAdd){
		gameObject.rigidbody2D.AddForceAtPosition (pushback+(pushback*pushStack), hitLocation, ForceMode.Impulse);
		addStack (stackAdd);
	}

	private void checkStack(){

		if (pushStack > maxStack) {
			pushStack = maxStack;
		}

		if (pushStack < minStack) {
			pushStack = minStack;
		}
		rigidbody2D.add

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
