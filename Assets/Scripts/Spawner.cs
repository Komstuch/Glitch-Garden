using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float meanSpwanDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1/ meanSpwanDelay;
		
		if(Time.deltaTime > meanSpwanDelay){
			Debug.Log ("Spawn rate capped by frame rate");
		} 
		
		float threshold = spawnsPerSecond * Time.deltaTime/5; // By multiplying by Time.deltaTime we "convert" the calculation from frames to seconds (/5 because of 5 lanes)
		
		if(Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}
}
