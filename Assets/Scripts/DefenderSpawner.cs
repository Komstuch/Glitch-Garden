using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 snapPos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defender>().starCost;
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){ //The total ammount of stars is substracted heres
			SpawnDefender (snapPos, defender);
		}
	}

	void SpawnDefender (Vector2 pos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, pos, zeroRot) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX =  Mathf.RoundToInt(rawWorldPos.x);
		float newY =  Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = this.transform.position.z - Camera.main.transform.position.z;
		
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
}
