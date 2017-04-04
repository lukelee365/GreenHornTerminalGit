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
	public  int progressID;
	private ChatTextFilled chatText;
	private AutoScrollDown autoScroll;
	// Use this for initialization

	void OnEnable(){
		dialogue_option1.onClick.AddListener (Option1_Clicked);
		dialogue_option2.onClick.AddListener (Option2_Clicked);
		dialogue_option3.onClick.AddListener (Option3_Clicked);
		dialogue_option4.onClick.AddListener (Option4_Clicked);
	}
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
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
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"How can I help ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("emailfirst"));
			progressID++;
		} else if (dialogue_text [0].text == "Yes") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"Yes"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("yes"));
		
		}else if (dialogue_text [0].text == "Who is Vance Kalken ?") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"Who is Vance Kalken ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("vance"));

		}else if (dialogue_text [0].text == "Why is he friendly with the folks from Arcadia ?") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"Why is he friendly with the folks from Arcadia ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("folks"));
		}else if (dialogue_text [0].text == "I'm not sure what to do with this code") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"I'm not sure what to do with this code"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("hint"));
		}else if (dialogue_text [0].text == "What is IPCC ?") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"What is IPCC ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("ipcc"));

		}else if (dialogue_text [0].text == "So I'm looking for a password ?") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"So I'm looking for a password ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("password"));

		}else if (dialogue_text [0].text == "Why isn’t Arcadia responding ?") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"Why isn’t Arcadia responding ?"+"</color>";
			autoScroll.ChatScroll ();
			StartCoroutine(chatText.ShowChat("arcadia"));

		}
	}

	void Option2_Clicked(){
		if (dialogue_text [1].text == "No") {
			textPanel.text = textPanel.text+"\n"+"<color=#99ff33>"+"[CODENAME]: "+"No"+"</color>";
			autoScroll.ChatScroll ();
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
