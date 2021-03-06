﻿using UnityEngine;
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
	
	public void setReady(bool ready){
		isReady = ready;
	}

	public virtual void cast(GameObject playerID){
		instanceCreate (playerID);
	}

	public virtual void instanceCreate(GameObject playerID){
		var castedAbility = Instantiate(instance) as Transform;
		castedAbility.position = playerID.transform.position;
	}
	// Use this for initialization
	void Awake () {
		isReady = true;
		casttime = 0.2f;
	}

}
