using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    private Animator animator;
    private GameObject currentTarget;
    private List<GameObject> Targets = new List<GameObject>(); // List of tagets which are currently colliding with the mine

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        if (Targets.Count > 0) {
            animator.SetBool("isUnderEnemy", true);
        }
        else {
            animator.SetBool("isUnderEnemy", false);
        }
	}

    //Add Enemy to Targets list as they enter the Raibow Collider
    void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.GetComponent<Attacker>()) {
            Targets.Add(collision.gameObject);
        }
    }

    //Remove Enemy from Targets list as they exit the Raibow Collider
    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.GetComponent<Attacker>())
        {
            Targets.Remove(collision.gameObject);
        }
    }

    //Deal damage to all attackers on the "Targets" list - method called from the animator
    void StrikeAllAttackers(float damage){
        foreach (GameObject currentTarget in Targets) {
            
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
                print("Dealt: " + damage +" to: " + currentTarget.name);
            }
        }
    }

}
