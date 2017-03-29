using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {
	public GameObject[] Panels;
	public Button[] PanelButtons;// the button of all the tags
		public RectTransform MailPanel;
	public RectTransform[] BottomLayer;// all the botton layrt two textviewes, and InputextFied
	public RectTransform[] TopPanelLayer;
	public RectTransform[] TopLayer;
	public bool adjustFirst;

	public bool test;
	public GameObject [] PanelButtonsObjs; // the gameobject of the button iteself, Using in other class to disable
	public GameObject btn_Email;
	private bool change;
	private float keyboardHeight;

	// Use this for initialization
	void Start () {
		EnablePanel ("Panel_Content_Notes");
		BtnInteactAll ("Notes");
		DisableMailPanel ();
		adjustFirst = false;
		change = true;
		test = false;
	}
		
	void FixedUpdate(){

		//ForIpad
//		if (TouchScreenKeyboard.visible == true) {
//			TouchScreenKeyboard.hideInput = true;
//			AdjustBottomLayerWhenKeyBoardShows ();
//			adjustFirst = true;
//		} else if(TouchScreenKeyboard.visible == false && adjustFirst == true) {
//			RestoreBottomLayerWhenKeyBoardShows ();
//			adjustFirst = false;
//		}
		// For Tesing Simulating KeyBoard Up
//
//		if (test == true) {
//			TouchScreenKeyboard.hideInput = true;
//			AdjustBottomLayerWhenKeyBoardShows ();
//			adjustFirst = true;
//		} else if(test == false && adjustFirst == true) {
//			RestoreBottomLayerWhenKeyBoardShows ();
//			adjustFirst = false;
//		}
//
	}


	//Adjust Layer when the KyeBorad Show
	void AdjustBottomLayerWhenKeyBoardShows(){
		if (change) {
			foreach (RectTransform RT in BottomLayer) {
				RT.position = new Vector3 (RT.position.x, RT.position.y + 5f, RT.position.z);//775
			}
			ChangeTopLayer ();
			ChangeTopPanelLayer ();
			change = false;
		}
	}
	//Adjust the layer Back when keyBoard Hide
	void RestoreBottomLayerWhenKeyBoardShows(){

			foreach (RectTransform RT in BottomLayer) {
				RT.position = new Vector3 (RT.position.x, RT.position.y - 5f, RT.position.z);
			}
		RestoreTopLayer ();
		RestoreTopPanelLayer ();
		change = true;

	}
	//Only change the content if the content don't have the tittle inside the panel like Map and Message
	void ChangeTopLayer(){
		foreach (RectTransform RT in TopLayer) {
			RT.sizeDelta = new Vector2 (RT.sizeDelta.x, 180);
		}
	}
	void RestoreTopLayer(){
		foreach (RectTransform RT in TopLayer) {
			RT.sizeDelta = new Vector2 (RT.sizeDelta.x, 950f);
		}
	}
	//SomeTime need to change the Panel if it Cantain a Tittle in panel too;
	void ChangeTopPanelLayer(){
		foreach (RectTransform RT in TopPanelLayer) {
			RT.sizeDelta = new Vector2 (RT.sizeDelta.x, 308);
		}
	}
	void RestoreTopPanelLayer(){
		foreach (RectTransform RT in TopPanelLayer) {
			RT.sizeDelta = new Vector2 (RT.sizeDelta.x, 1080);
		}
	}
	//Enable some panes called by the buttons
	public void EnablePanel(string panelName){
		foreach (GameObject panel in Panels) {
			if (panel.name == panelName) {
				panel.SetActive (true);
			} else {
				panel.SetActive (false);
			}

		}
	}
	// Function used before as Panel
//	public void EnableContentPanel(string panelName){
//		foreach (GameObject panel in Panels) {
//			if (panel.name == panelName) {
//				panel.SetActive (true);
//			}
//
//		}
//	}

	//When Button or Left Panel Get pressed Create the Layer of  mail changed, and Disable the Button Get clicked
	public void BtnInteactAll(string BtnName){
		foreach (Button btn in PanelButtons) {
			if (btn != null) {
				if (btn.name == BtnName) {
					if (btn.name == "Mail") {
						EnableMailPanel ();
						btn.interactable = false;
						btn_Email.SetActive (true);
					} else {
						btn.interactable = false;
						DisableMailPanel ();
						//btn_Email.SetActive (false);
					}
				} else {
					btn.interactable = true;
					btn_Email.SetActive (false);
				}
			}
		}
	
	}

	// The Change of the Panel
	public void DisableMailPanel(){

		PanelButtons [4].gameObject.SetActive(false);
	
		MailPanel.sizeDelta = new Vector2 (437, 118);
	}
	public void EnableMailPanel(){

		PanelButtons [4].gameObject.SetActive(true);

		MailPanel.sizeDelta = new Vector2 (437, 220);
	}

	// For Button to Open An URL
	public void OpenLink(string URLLink){
		Application.OpenURL (URLLink);
	}

}
