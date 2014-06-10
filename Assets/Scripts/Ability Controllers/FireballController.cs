using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	public void fireBall(Vector3 fireballDir, float speed, float angle)
	{
			if (fireballDir != Vector3.zero)
			{
				rigidbody2D.velocity = fireballDir * speed * Time.deltaTime;
				transform.rotation =
				Quaternion.Slerp (transform.rotation,
				                  Quaternion.Euler (0, 0, angle),
				                  100 * Time.deltaTime);
			}
	}

}