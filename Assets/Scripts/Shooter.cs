using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	
	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;	
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	void Start () {
		projectileParent = GameObject.Find("Projectiles");
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
	}
	
}
