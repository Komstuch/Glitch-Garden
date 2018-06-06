using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    private Animator animator;
    private GameObject currentTarget;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

    //Set the attacking flag as colliders enter
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.GetComponent<Attacker>()) {
            animator.SetBool("isUnderEnemy", true);
            DamageOverTime(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>()){
            animator.SetBool("isUnderEnemy", false);
        }
    }

    void StrikeCurrentAttacker(float damage){
        if (currentTarget){
            Health health = currentTarget.GetComponent<Health>();
            if (health){
                health.DealDamage(damage);
            }
        }
    }

    void DamageOverTime(GameObject obj){
        currentTarget = obj;

    }

}
