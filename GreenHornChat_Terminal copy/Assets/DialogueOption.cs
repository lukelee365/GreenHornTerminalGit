using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOption : MonoBehaviour {
	public GameObject[] dialogue;
	public Button dialogue_option1;
	public Button dialogue_option2;
	public Button dialogue_option3;
	public Button dialogue_option4;
	public Text[] dialogue_text;
	public Text textPanel;
	private ChatTextFilled chatText;

	// Use this for initialization

	void OnEnable(){
		dialogue_option1.onClick.AddListener (Option1_Clicked);
		dialogue_option2.onClick.AddListener (Option2_Clicked);
		dialogue_option3.onClick.AddListener (Option3_Clicked);
		dialogue_option4.onClick.AddListener (Option4_Clicked);
	}
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void EnableDialogueOption(int num){
		for (int i = 0; i < num; i++) {
			dialogue [i].SetActive (true);
		}
	}
	public void DisableDialogueOption(){
		for (int i = 0; i < dialogue.Length; i++) {
			dialogue [i].SetActive (false);
		}
	}
	void Option1_Clicked(){
		if (dialogue_text [0].text == "How can I help ?") {
			textPanel.text = textPanel.text+"\n"+"<color=Green>"+"How Can I Help ?"+"</color>";
			StartCoroutine(chatText.ShowChat("emailfirst"));
		} else if (dialogue_text [0].text == "Yes") {
			textPanel.text = textPanel.text+"\n"+"<color=Green>"+"Yes"+"</color>";
			StartCoroutine(chatText.ShowChat("yes"));
		}else if (dialogue_text [0].text == "Who is Vance Kalken ?") {
			textPanel.text = textPanel.text+"\n"+"<color=Green>"+"Who is Vance Kalken ?"+"</color>";
			StartCoroutine(chatText.ShowChat("vance"));
		}else if (dialogue_text [0].text == "Why is he friendly with the folks from Arcadia ?") {
			textPanel.text = textPanel.text+"\n"+"<color=Green>"+"Why is he friendly with the folks from Arcadia ?"+"</color>";
			StartCoroutine(chatText.ShowChat("folks"));
		}else if (dialogue_text [0].text == "I'm not sure what to do with this code") {
			textPanel.text = textPanel.text+"\n"+"<color=Green>"+"I'm not sure what to do with this code"+"</color>";
			StartCoroutine(chatText.ShowChat("hint"));
		}
	}

	void Option2_Clicked(){
		if (dialogue_text [1].text == "No") {
			StartCoroutine(chatText.ShowChat("no"));
		}
	}
	void Option3_Clicked(){
		Debug.Log (3);
	}
	void Option4_Clicked(){
		Debug.Log (4);
	}

}
