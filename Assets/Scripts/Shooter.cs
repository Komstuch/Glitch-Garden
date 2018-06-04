using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator shooterAnimator;
	private Spawner myLaneSpawner;
	
	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;	
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	void Start () {
		shooterAnimator = GetComponent<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		
		// Create a parent if necessary
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update(){
		if(isAttackerAheadInLane()){
			shooterAnimator.SetBool ("isAttacking", true);
		} else {
			shooterAnimator.SetBool("isAttacking", false);
		}	
	}
	// Look through all lane spawners and set myLanSpawner if found (we search by the y coordinate)
	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner currentSpawner in spawnerArray){
			if(currentSpawner.transform.position.y == transform.position.y){
				myLaneSpawner = currentSpawner;
				return;
			}
		}
		Debug.LogError("Can't find spawner in the lane");
	}
	
	bool isAttackerAheadInLane(){
		// Exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <=0){
			return false;
		}
		
		// If there are attackers, are they ahead?
		foreach (Transform attacker in myLaneSpawner.transform){ //Explained in unity docs - transform allows to enumerate by it's children
			if(attacker.transform.position.x > transform.position.x){ //Check if child of Spawner has x position greater than our defender
				return true;
			}
		}
		//Attackers in lane but behind us
		return false;	
	}
}
// animator = GetComponent<Animator>();