﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Attacker))] 	// If we add in future Fox.cs script to a Game Object Unity will check if we also have the attacker.
// If not it will add the Attacker componet for us
public class Lizard : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		
		GameObject obj = collider.gameObject;
		
		// Leave the method if not colliding with a defender
		if(!obj.GetComponent<Defender>()) {
			return;
		}

		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
		
		//Debug.Log ("Lizzard collided with " + collider);
		
	}
}
