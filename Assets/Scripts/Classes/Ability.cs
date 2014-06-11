using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour{

	// Variables for each ability
	public float casttime;
	public float cooldown;
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;

	public bool isReady;
	public bool isCast;
	public Transform instance;

	private void castCheck(){
		isCast = Input.GetButtonDown("Fire1");
	}

	public bool getIsCasting(){
		castCheck();
		return isCast;
	}

	public void cooldownCount(){
		isReady = true;
	}

	public virtual void cast(GameObject playerID){
		isReady = false;
		instanceCreate (playerID);
		Invoke ("cooldownCount", (cooldown+casttime));
	}

	public virtual void instanceCreate(GameObject playerID){
		Debug.Log("old running");
		var castedAbility = Instantiate(instance) as Transform;
		castedAbility.position = playerID.transform.position;
	}
	// Use this for initialization
	void Awake () {
		isReady = true;
		casttime = 0.2f;
	}

}
