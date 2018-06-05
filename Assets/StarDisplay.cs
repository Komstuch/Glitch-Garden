using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars = 0;
	
	void Start(){
		starText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars(int ammount){
		stars += ammount;
		UpdateDisplay();
	}
	
	public void UseStars( int ammount){
		
	}
	
	private void UpdateDisplay(){
		starText.text = stars.ToString();
	}
}
