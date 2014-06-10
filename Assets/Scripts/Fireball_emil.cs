using UnityEngine;
using System.Collections;

public class Fireball_emil : MonoBehaviour {
	
	public GameObject fireballPrefab;
	public Transform playerID;
	public float speed;
	public float range;
	public float cooldown;
	
	private float castTurnSpeed = 100;
	private bool isReady = true;
	private float animationTimer = 0.2f;
	
	// Use this for initialization
	void Start () 
	{
		speed *= 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("Fire1") && isReady)
		{
			isReady = false;
			Invoke("createFireball", animationTimer);
			Invoke("cooldownFireball", cooldown);
			if(playerID.GetComponent<Animator>().GetBool("casting") == false)
			{
				playerID.GetComponent<Animator>().SetBool("casting", true);
			}
			
			
			
		}
	}
	
	public void createFireball()
	{	
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		Vector3 fireballDir = mousePos - currentPosition;
		fireballDir.z = 0;
		fireballDir.Normalize ();
		float angle = Mathf.Atan2 (fireballDir.y, fireballDir.x) * Mathf.Rad2Deg;
		GameObject fireballID = (GameObject)Instantiate (fireballPrefab, currentPosition + fireballDir/2, Quaternion.identity);
		FireballController fireballController = 
			(FireballController)fireballID.GetComponent<FireballController>();
		fireballController.SetfireBall (fireballDir, speed, angle);
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
	}
	
	public void cooldownFireball()
	{
		isReady = true;
	}
}