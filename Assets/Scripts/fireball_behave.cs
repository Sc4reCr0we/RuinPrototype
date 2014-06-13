using UnityEngine;
using System.Collections;

public class fireball_behave : MonoBehaviour {
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;

	// Use this for initializationd
	void Start () {
	
	}
	
	// Update is called once per framee
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

		if (other != null && other.gameObject.tag== "Player") {
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
			Debug.Log ("hit!");
			Destroy (gameObject);
		}
		if (other != null && other.gameObject.tag== "Ability") {
			Destroy (gameObject);
		}

		if (other != null && other.gameObject.tag == "Destructable") {
			other.gameObject.GetComponent<HealthScriptDestruct>().setHealth(damage);
			Destroy (gameObject);
		}
	}
}
