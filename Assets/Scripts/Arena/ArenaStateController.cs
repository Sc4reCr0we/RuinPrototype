using UnityEngine;
using System.Collections;

public class ArenaStateController : MonoBehaviour {
	public float firstStateChangeTimer;
	public float secondStateChangeTimer;
	public float thirdStateChangeTimer;
	
	private float colliderRadius;	
	private Animator animator;
	private CircleCollider2D collider;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		collider = GetComponent<CircleCollider2D> ();
		colliderRadius = collider.radius;
		Invoke ("isState_2", firstStateChangeTimer);
		Invoke ("isState_3", secondStateChangeTimer);
		Invoke ("isState_4", thirdStateChangeTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void isState_2()
	{
		animator.SetBool ("isState_2", true);
		collider.radius = colliderRadius * 0.75f;

	}

	public void isState_3()
	{

		animator.SetBool ("isState_3", true);
		collider.radius = colliderRadius * 0.5f;
	}

	public void isState_4()
	{
		animator.SetBool ("isState_4", true);
		collider.radius = colliderRadius * 0.25f;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
						Debug.Log ("Player Entered Arena");
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
			Debug.Log ("WARNING! Player is Outside Arena");
	}

}
