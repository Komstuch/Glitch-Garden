using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManager levelmanager;
	
	void Start(){
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(){
		levelmanager.LoadLevel("03b Lose");
	}
}
