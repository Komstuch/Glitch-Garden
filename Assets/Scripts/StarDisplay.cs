using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars = 100;
	public enum Status {SUCCESS, FAILURE};
	
	void Start(){
		starText = GetComponent<Text>();
        if (Application.loadedLevel.ToString() == "5") {
            stars = 150;
        }
		UpdateDisplay();
	}
	
	public void AddStars(int ammount){
		stars += ammount;
		UpdateDisplay();
	}
	
	public Status UseStars(int ammount){
		if(stars >= ammount){
			stars -= ammount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		starText.text = stars.ToString();
	}
}
	

