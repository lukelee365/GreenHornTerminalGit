using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePadGatTextInput : MonoBehaviour {
	public InputField NotePad;

	// Use this for initialization
	void Start () {
		//loading things
		NotePad.text = GameManager.gameManager.notes;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GetInputField(){
		
		GameManager.gameManager.notes = NotePad.text;
	}
	public void SaveNotePadInputField(){
		GameManager.gameManager.SaveData ();

	}
	public void CleanTheSavedData(){
		GameManager.gameManager.CleanData ();
	}
}
