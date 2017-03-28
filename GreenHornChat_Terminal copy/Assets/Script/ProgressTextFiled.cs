﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextChunk{
	public string name;
	public string[] progressTextModular;
}
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class ProgressTextFiled : MonoBehaviour {

	public TextChunk[] textChunks;
	public float interval;
	public Text textPanel;
	private ChatTextFilled chatText;
	private AutoScrollDown autoScroll;
	public GameObject[] EmailsSet1;
	public GameObject[] EmailsSet2;
	private NotificationControl notificationC;
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
		notificationC = GetComponent<NotificationControl> ();
		StartCoroutine (ShowProgress ("init"));
		foreach (GameObject objs in EmailsSet1) {
			objs.SetActive (false);
		}
		foreach (GameObject objs in EmailsSet2) {
			objs.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowProgress(string chunkName){
		//SearchNameofThetextChunk	and show the text in some delay
		chunkName = chunkName.ToLower();
		for (int i = 0; i < textChunks.Length; i++) {
			//find the match name of the text Chunk
		if (textChunks [i].name.ToLower() == chunkName) {
				//loop through each text in modular
				if (chunkName == "init") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							StartCoroutine(chatText.ShowChat("init"));
						}
					}
				}else if (chunkName == "emailfirst") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							EnableEmailSet(EmailsSet1);
							StartCoroutine(chatText.ShowChat("emailsecond"));
						

						}
					}
				}else if (chunkName == "emailsecond") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							autoScroll.ProgressScroll ();
							EnableEmailSet(EmailsSet2);

						}
					}
				}else {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
					}
				}
			} 
			}

	}
	void DelaySecondEmail(){
		EnableEmailSet(EmailsSet2);
	}

	public void EnableEmailSet(GameObject[] Email){
		foreach (GameObject objs in Email) {
			objs.SetActive (true);

		}
		notificationC.AddNotification (Email.Length);
	}




}