using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	
	public float fadeInTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime){
			// Fade In
			float alphaChange = Time.deltaTime/fadeInTime;
			currentColor.a -= alphaChange; // Alpha is set form 0 to 1 (we deduct fractions of 1 on every update
			fadePanel.color = currentColor;
		
		} else {
			gameObject.SetActive(false);
		}
	}
}
