using System.Collections;
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
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
		StartCoroutine (ShowProgress ("init"));
		foreach (GameObject objs in EmailsSet1) {
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
			if (textChunks [i].name.ToLower () == "init") {
				//loop through each text in modular
				for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
					yield return new WaitForSeconds (interval);
					textPanel.text = textPanel.text+"\n"+"<color=#2ce7d8>"+"   "+textChunks [i].progressTextModular [j]+"</color>";
					if (j == textChunks [i].progressTextModular.Length - 1) {
						//Something happen at the end
						//ini the Chat Text
						StartCoroutine(chatText.ShowChat("init"));

					}
				}
			}else if (textChunks [i].name.ToLower() == chunkName) {
				//loop through each text in modular
				for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
					yield return new WaitForSeconds (interval);
					textPanel.text = textPanel.text+"\n"+"<color=#2ce7d8>"+"   "+textChunks [i].progressTextModular [j]+"</color>";
					autoScroll.ProgressScroll ();
				}
			} else {
				yield break;
			}
			}

	}

	public void EnableEmails(){
		foreach (GameObject objs in EmailsSet1) {
			objs.SetActive (true);
		}
	}
}
