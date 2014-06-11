using UnityEngine;
using System.Collections;

public class slotManager : MonoBehaviour {
	
	public Ability Q_slot;
	public Ability E_slot;
	public Ability R_slot;
	public Ability Spc_slot;

	private Ability currentSlot;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	private void slotReady(){
		currentSlot.isReady = true;
	}


	private void setActiveSlot(){
		// Check each button for press and set the current slot correspondinlgy
		bool Q_shoot = Input.GetButtonDown("Qkey");
		bool E_shoot = Input.GetButtonDown("Ekey");
		bool R_shoot = Input.GetButtonDown("Rkey");
		bool Spc_shoot = Input.GetButtonDown("Space");
		
		if(R_shoot == true){
			currentSlot = R_slot;
			Q_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
		}
		else if(Q_shoot == true){
			currentSlot = Q_slot;
			R_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
		}
		else if(E_shoot == true){
			currentSlot = E_slot;
			R_shoot = false;
			Q_shoot = false;
			Spc_shoot = false;
		}
		else if(Spc_shoot == true){
			currentSlot = Spc_slot;
			Q_shoot = false;
			E_shoot = false;
			R_shoot = false;
		}
	}

	private void castdelay(){
		currentSlot.cast(gameObject);
		}


	// Update is called once per frame
	void Update () {
		setActiveSlot ();
		if (currentSlot != null) {
			if(currentSlot.getIsCasting () && currentSlot.isReady){
				animator.SetBool ("casting", true);
				Invoke("castdelay",0.2f);
			}

		}
	}
}
