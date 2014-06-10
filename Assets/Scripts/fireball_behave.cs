using UnityEngine;
using System.Collections;

public class fireball_behave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onCast(Vector3 fireballDir, float speed, float angle){
		rigidbody2D.velocity = fireballDir * speed * Time.deltaTime;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);
	}

	void Destroy(){

	}
}
