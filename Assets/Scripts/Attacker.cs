using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	//[Range(-1f, 1.5f)] public float currentSpeed; - give constrains to a value
	private float currentSpeed;
	[Tooltip("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime); // Move the attacker
		if(!currentTarget){
			animator.SetBool("isAttacking", false);
		}

	}
	
	public void SetSpeed (float speed){
		currentSpeed = speed;
	} 
	
	// Called from the Animator at the time of an actual attack
	public void StrikeCurrentTarget (float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	
	}
}
