using UnityEngine;
using System.Collections;

public class fireball_behave : MonoBehaviour {
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onCast (Vector3 fireballDir, float speed1, float angle) {
		rigidbody2D.velocity = fireballDir * speed1 * Time.deltaTime;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("hit!");
		if (other != null && other.gameObject.tag== "Player") {
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts, pushback,pushStack);
				Destroy (gameObject);
		}
		if (other != null && other.gameObject.tag== "Ability") {
			Destroy (gameObject);
		}
	}
}
